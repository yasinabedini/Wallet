using Framework.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wallet.Application.Models.Wallet.Commands.TransferMoney
{
    public class TransferMoneyCommand:ICommand<string>
    {
        public int SourceWalletId { get; set; }     
        public List<Tuple<int, int>> DestinationWallets { get; set; }

   
    }
}
