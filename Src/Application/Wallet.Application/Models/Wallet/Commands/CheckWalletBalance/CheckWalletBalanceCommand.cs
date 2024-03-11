using Framework.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wallet.Application.Models.Wallet.Commands.CheckWalletBalance
{
    public class CheckWalletBalanceCommand:ICommand<bool>
    {
        public int WalletId { get; set; }
        public int RequestedAmount { get; set; }

        public CheckWalletBalanceCommand(int walletId, int requestedAmount)
        {
            WalletId = walletId;
            RequestedAmount = requestedAmount;
        }
    }
}
