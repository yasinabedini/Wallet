using Framework.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet.Application.Models.Wallet.Queries.Common;

namespace Wallet.Application.Models.Wallet.Queries.GetWalletByPhoneNumber
{
    public class GetWalletByPhoneNumberQuery:PageQuery<PagedData<WalletResult>>
    {
        public string PhoneNumber { get; set; }

        public GetWalletByPhoneNumberQuery(string phoneNumber)
        {
            PhoneNumber = phoneNumber;
        }
    }
}
