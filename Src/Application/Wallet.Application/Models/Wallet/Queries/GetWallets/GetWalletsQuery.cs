using Framework.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet.Application.Models.Wallet.Queries.Common;

namespace Wallet.Application.Models.Wallet.Queries.GetWallets
{
    public class GetWalletsQuery:PageQuery<PagedData<WalletResult>>
    {
    }
}
