namespace Blockcore.Features.Wallet.Api.Models.XDocuments
{
    public class XDocumentCreateModel
    {
        public int DocumentType { get; set; }
        public int InstructionType { get; set; }
        public string KeyAddress { get; set; }
        public object Data { get; set; }
        public string Wallet { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }

        public XDocumentCreateModel()
        {

        }

    }
}
