using System.Threading.Tasks;
using Blockcore.Features.Wallet.Types;

namespace Blockcore.Features.Wallet
{
    public interface IMultisigManager
    {
        Task<string> BuildFullySignedTransactionAsync(BuildFullySignedTransactionInput input);
        Task<string> CreateUnsignedMultisigPayment(SpendMultisigInput input);
        Task<string> FundMultisigAsync(FundMultisigInput input);
        Task<string> SignMultisigPaymentAsync(PartiallySignedMultisigInput input);
    }
}