using Framework.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wallet.Application.Models.Wallet.Commands.ProductPurchase
{
    public class ProductPurchaseCommand:ICommand<string>
    {
        public int WalletId { get; set; }
        public int Amount { get; set; }
    }
}
