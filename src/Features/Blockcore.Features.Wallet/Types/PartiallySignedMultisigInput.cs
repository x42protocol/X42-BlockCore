namespace Blockcore.Features.Wallet.Types
{
    public class PartiallySignedMultisigInput
    {
        public string FundingTransactionHex { get; set; }
        public string TransactionHex { get; set; }
        public string WalletName { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }
        public string SignAddress { get; set; }
        public string DesinationAddress { get; set; }
        public decimal Amount { get; set; }
    }
}
