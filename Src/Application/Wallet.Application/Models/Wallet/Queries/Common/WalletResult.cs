using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet.Domain.Common.ValueObjects;

namespace Wallet.Application.Models.Wallet.Queries.Common
{
    public class WalletResult
    {
        public long Id { get; set; }
        public string WalletTitle { get; private set; }
        public string PhoneNumber { get; private set; }
        public int WalletBalance { get; private set; }

        public WalletResult(long id, string walletTitle, string phoneNumber, int walletBalance)
        {
            Id = id;
            WalletTitle = walletTitle;
            PhoneNumber = phoneNumber;
            WalletBalance = walletBalance;
        }
    }
}
