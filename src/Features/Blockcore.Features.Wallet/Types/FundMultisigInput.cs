using System.Collections.Generic;

namespace Blockcore.Features.Wallet.Types
{
    public class FundMultisigInput
    {
        public decimal Amount { get; set; }
        public List<string> PublicKeys { get; set; }
        public string Wallet { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }

        public FundMultisigInput()
        {

        }
    }
}
