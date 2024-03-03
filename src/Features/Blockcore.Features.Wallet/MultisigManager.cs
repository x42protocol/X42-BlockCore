using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blockcore.Consensus;
using Blockcore.Consensus.ScriptInfo;
using Blockcore.Consensus.TransactionInfo;
using Blockcore.Features.Wallet.Interfaces;
using Blockcore.Features.Wallet.Types;
using Blockcore.Interfaces;
using Blockcore.NBitcoin;
using Blockcore.Networks;
using NBitcoin;

namespace Blockcore.Features.Wallet
{
    public class MultisigManager : IMultisigManager
    {
        private readonly Network _network;
        private readonly IWalletTransactionHandler _walletTransactionHandler;
        private readonly IWalletManager _walletManager;
        private readonly IBroadcasterManager _broadcasterManager;
        private readonly IConsensusManager _consensusManager;
        private readonly IBlockStore _blockStore;

        public MultisigManager(Network network, IWalletTransactionHandler walletTransactionHandler, IWalletManager walletManager, IBroadcasterManager broadcasterManager, IConsensusManager consensusManager, IBlockStore blockStore)
        {
            this._network = network;
            this._walletTransactionHandler = walletTransactionHandler;
            this._walletManager = walletManager;
            this._broadcasterManager = broadcasterManager;
            this._consensusManager = consensusManager;
            this._blockStore = blockStore;
        }

        public async Task<string> FundMultisigAsync(FundMultisigInput input)
        {

            var listOfPubKeys =
                input
                .PublicKeys
                .Select(l => new PubKey(l))
                .ToList();

            // require minimum of 50% consensus
            var minimumSignatories = (listOfPubKeys.Count / 2) + 1;

            //create multisig script for multi-sig payment
            var multisigScript = PayToMultiSigTemplate
                .Instance
                .GenerateScriptPubKey(minimumSignatories, listOfPubKeys.ToArray());

            //fund the multisig script
            var recipients = new List<Recipient>() { new Recipient
            {
                ScriptPubKey = multisigScript,
                Amount = Money.Coins(input.Amount)
            }};


            var transactionBuildContext = new TransactionBuildContext(this._network)
            {
                AccountReference = new WalletAccountReference(input.Wallet, input.Account),
                TransactionFee = Money.Parse("0"),
                MinConfirmations = 1,
                Shuffle = false,
                WalletPassword = input.Password,
                AllowOtherInputs = false,
                Recipients = recipients,
            };

            Transaction fundingTransaction = _walletTransactionHandler.BuildTransaction(transactionBuildContext);

            // process and breadcast transaction
            _walletManager.ProcessTransaction(fundingTransaction);

            await _broadcasterManager.BroadcastTransactionAsync(fundingTransaction);

            return fundingTransaction.ToHex();

        }


        public Task<string> CreateUnsignedMultisigPayment(SpendMultisigInput input)
        {

            var wallet = this._walletManager.GetWallet(input.WalletName);
            var hdAddress = wallet.GetAddress(input.SignAddress, account => account.Name.Equals(input.Account));
            ISecret privateKey = wallet.GetExtendedPrivateKeyForAddress(input.Password, hdAddress).PrivateKey.GetWif(_network);

            Transaction transaction = this._network.CreateTransaction(input.TransactionHex);
            var trxhash = transaction.GetHash();


            var blockHash = this._blockStore.GetBlockIdByTransactionId(trxhash);

            var chainedHeaderBlock = this._consensusManager.GetBlockData(blockHash);

            var trx = chainedHeaderBlock.Block.Transactions.SingleOrDefault(t => t.GetHash() == trxhash);

            var txBuilderNew = new TransactionBuilder(this._network);

            Coin coin = trx.Outputs.AsCoins().Where(l => l.ScriptPubKey.ToString().Contains("OP_CHECKMULTISIG")).Last();

            var pubkeys = coin.ScriptPubKey.GetDestinationPublicKeys(this._network);

            var redeemScript = PayToMultiSigTemplate
                .Instance
                .GenerateScriptPubKey((pubkeys.Count() / 2) + 1, pubkeys);

            Transaction unsigned =
                txBuilderNew
                .AddCoins(coin)
                .Send(new BitcoinPubKeyAddress(input.DesinationAddress, this._network), Money.Satoshis(input.Amount*100*1000*1000))
                .SetChange(redeemScript)
                .BuildTransaction(sign: false);
       
            var signedTransactions = new List<Transaction>();

            txBuilderNew = new TransactionBuilder(this._network);

            return Task.FromResult(unsigned.ToHex());

        }

        public async Task<string> SignMultisigPaymentAsync(PartiallySignedMultisigInput input)
        {

            var wallet = this._walletManager.GetWallet(input.WalletName);
            var hdAddress = wallet.GetAddress(input.SignAddress, account => account.Name.Equals(input.Account));
            ISecret privateKey = wallet.GetExtendedPrivateKeyForAddress(input.Password, hdAddress).PrivateKey.GetWif(this._network);

            Transaction transaction = this._network.CreateTransaction(input.TransactionHex);
            Transaction fundingTransaction = this._network.CreateTransaction(input.FundingTransactionHex);

            Coin coin = fundingTransaction.Outputs.AsCoins().Where(l => l.ScriptPubKey.ToString().Contains("OP_CHECKMULTISIG")).Last();

            var pubkeys = coin.ScriptPubKey.GetDestinationPublicKeys(this._network);

            var transactionBuilder = new TransactionBuilder(this._network);

            Transaction signedTransaction =
                transactionBuilder
                .AddCoins(coin)
                .AddKeys(privateKey.PrivateKey)
                .SignTransaction(transaction);

            return await Task.FromResult(signedTransaction.ToHex());

        }


        public async Task<string> BuildFullySignedTransactionAsync(BuildFullySignedTransactionInput input)
        {

            Transaction unsigned = this._network.CreateTransaction(input.FundingTransactionHex);

            Coin coin = unsigned.Outputs.AsCoins().Where(l => l.ScriptPubKey.ToString().Contains("OP_CHECKMULTISIG")).Last();
            var signedTransactions = new List<Transaction>();

            foreach (var signedTransactionHex in input.SignedTransactionHexes)
            {
                Transaction signedTransaction = this._network.CreateTransaction(signedTransactionHex);
                signedTransactions.Add(signedTransaction);
            }

            var txBuilderNew = new TransactionBuilder(this._network);

            Transaction fullySigned =
                txBuilderNew
                .AddCoins(coin)
                .CombineSignatures(signedTransactions.ToArray());

            this._walletManager.ProcessTransaction(fullySigned);

            this._broadcasterManager.BroadcastTransactionAsync(fullySigned).GetAwaiter().GetResult();

            return await Task.FromResult(fullySigned.ToHex());


        }
    }
}
