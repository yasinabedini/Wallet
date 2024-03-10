using Framework.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wallet.Application.Models.Wallet.Commands.WithdrawFromWallet
{
    public class WithdrawFromWalletCommand:ICommand<string>
    {
        public int WalletId { get; set; }
        public int Amount { get; set; }

        public WithdrawFromWalletCommand(int walletId, int amount)
        {
            WalletId = walletId;
            Amount = amount;
        }
    }
}
