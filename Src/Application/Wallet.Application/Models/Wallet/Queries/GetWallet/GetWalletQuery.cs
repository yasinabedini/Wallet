using Framework.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet.Application.Models.Wallet.Queries.Common;

namespace Wallet.Application.Models.Wallet.Queries.GetWallet
{
    public class GetWalletQuery:IQuery<WalletResult>
    {
        public int Id { get; set; }

        public GetWalletQuery(int id)
        {
            Id = id;
        }
    }
}
