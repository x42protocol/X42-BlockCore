using Newtonsoft.Json;

namespace Blockcore.Features.Wallet.Api.Models.XDocuments
{
    public class XDocumentModel
    {
        [JsonProperty("documentType")]
        public int DocumentType { get; set; }

        [JsonProperty("instructionType")]
        public int InstructionType { get; set; }

        [JsonProperty("keyAddress")]
        public string KeyAddress { get; set; }

        [JsonProperty("signature")]
        public string Signature { get; set; }

        [JsonProperty("data")]
        public object Data { get; set; }

        public XDocumentModel()
        {

        }

        public XDocumentModel(int documentType, int instructionType, string keyAddress, string signature, object data)
        {
            DocumentType = documentType;
            InstructionType = instructionType;
            KeyAddress = keyAddress;
            Signature = signature;
            Data = data;          

        }

    }
}
