using Framework.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wallet.Application.Models.Wallet.Commands.CheckWalletAvailability
{
    public class CheckWalletAvailabilityCommand:ICommand<bool>
    {
        public int Id { get; set; }

        public CheckWalletAvailabilityCommand(int id)
        {
            Id = id;
        }
    }
}
