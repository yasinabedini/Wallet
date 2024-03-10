using Framework.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wallet.Application.Models.Wallet.Commands.AddWallet
{
    public class AddWalletCommand:ICommand
    {
        public string Title { get; set; }
        public string PhoneNumber { get; set; }

        public AddWalletCommand(string title, string phoneNumber)
        {
            Title = title;
            PhoneNumber = phoneNumber;
        }
    }
}
