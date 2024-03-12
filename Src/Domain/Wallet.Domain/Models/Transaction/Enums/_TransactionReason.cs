using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wallet.Domain.Models.Transaction.Enums
{
    public enum _TransactionReason
    {
        ProductPurchase = 1,
        PayingBill = 2,
        RechargeWallet = 3,
        BuyMobileRecharge = 4,
        MoneyTransfer = 5,
        CashWithdrawal = 6,
        DepositToWallet = 7
    }
}
