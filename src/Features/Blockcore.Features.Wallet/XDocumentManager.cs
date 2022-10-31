using System;
using System.Threading.Tasks;
using Blockcore.Features.Wallet.Api.Models.XDocuments;
using Blockcore.Features.Wallet.Helpers;
using Blockcore.Features.Wallet.Interfaces;
using Newtonsoft.Json;

namespace Blockcore.Features.Wallet
{
    public class XDocumentManager : IXDocumentManager
    {
        private readonly IWalletManager _walletManager;

        public XDocumentManager(IWalletManager walletManager)
        {
            this._walletManager = walletManager;
 
        }

        public async Task<string> CreateDocument(XDocumentCreateModel input)
        {

            string data = JsonUtility.NormalizeJsonString(JsonConvert.SerializeObject(input.Data));

            if (input.KeyAddress != null && input.KeyAddress != "")
            {

                var result = this._walletManager.SignMessage(input.Password, input.Wallet, input.Account, input.KeyAddress, data);
                var xDocument = new XDocumentModel(input.DocumentType, input.InstructionType, input.KeyAddress, result.Signature, input.Data);

                return JsonUtility.NormalizeJsonString(JsonConvert.SerializeObject(xDocument));

            }

            else
            {
                throw new Exception("Key Address Missing");
            }
        }
    }
}
