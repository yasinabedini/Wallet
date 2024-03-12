using Framework.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wallet.Application.Models.Wallet.Commands.PayingBill
{
    public class PayingBillCommand:ICommand<string>
    {
        public int WalletId { get; set; }
        public string BillTitle { get; set; }
        public int BillAmount { get; set; }

        public PayingBillCommand(int walletId, string billTitle, int billAmount)
        {
            WalletId = walletId;
            BillTitle = billTitle;
            BillAmount = billAmount;
        }
    }
}
