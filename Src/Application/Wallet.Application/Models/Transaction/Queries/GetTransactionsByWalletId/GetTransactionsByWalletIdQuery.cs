using Framework.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet.Application.Models.Transaction.Queries.Common;

namespace Wallet.Application.Models.Transaction.Queries.GetTransactionsByWalletId
{
    public class GetTransactionsByWalletIdQuery:PageQuery<PagedData<TransactionResult>>
    {
        public int WalletId { get; set; }

        public GetTransactionsByWalletIdQuery(int walletId)
        {
            WalletId = walletId;
        }
    }
}
