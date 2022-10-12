using System.Collections.Generic;

namespace Blockcore.Features.Wallet.Types
{
    public class BuildFullySignedTransactionInput
    {
        public string FundingTransactionHex { get; set; }
        public List<string> SignedTransactionHexes { get; set; }

    }
}
