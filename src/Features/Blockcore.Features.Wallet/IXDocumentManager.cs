using System.Threading.Tasks;
using Blockcore.Features.Wallet.Api.Models.XDocuments;

namespace Blockcore.Features.Wallet
{
    public interface IXDocumentManager
    {
        Task<string> CreateDocument(XDocumentCreateModel input);
    }
}