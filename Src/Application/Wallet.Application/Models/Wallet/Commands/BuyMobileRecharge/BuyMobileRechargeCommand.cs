using Framework.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wallet.Application.Models.Wallet.Commands.BuyMobileRecharge
{
    public class BuyMobileRechargeCommand:ICommand<string>
    {
        public int WalletId { get; set; }
        public int RechargeAmount { get; set; }
        public string PhoneNumber { get; set; }

        public BuyMobileRechargeCommand(int walletId, int rechargeAmount, string phoneNumber)
        {
            WalletId = walletId;
            RechargeAmount = rechargeAmount;
            PhoneNumber = phoneNumber;
        }
    }
}
