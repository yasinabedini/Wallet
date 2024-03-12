using Framework.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet.Application.Models.Transaction.Queries.Common;

namespace Wallet.Application.Models.Transaction.Queries.GetTransactions
{
    public class GetTransactionsQuery:PageQuery<PagedData<TransactionResult>>
    {
    }
}
