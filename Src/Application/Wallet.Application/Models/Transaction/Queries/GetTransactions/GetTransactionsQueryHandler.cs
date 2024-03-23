using Framework.Queries;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet.Application.Models.Transaction.Queries.Common;
using Wallet.Domain.Models.Transaction.Repositories;

namespace Wallet.Application.Models.Transaction.Queries.GetTransactions
{
    public class GetTransactionsQueryHandler : IQueryHandler<GetTransactionsQuery, PagedData<TransactionResult>>
    {
        private readonly ITransactionRepository _repository;

        public GetTransactionsQueryHandler(ITransactionRepository repository)
        {
            _repository = repository;
        }

        public Task<PagedData<TransactionResult>> Handle(GetTransactionsQuery request, CancellationToken cancellationToken)
        {
            var transactions = _repository.GetList().Skip(request.SkipCount).Take(request.PageSize).ToList();
            Log.Information("List of transactions successfully retrieved");
            return Task.FromResult(new PagedData<TransactionResult> { PageNumber = request.PageNumber, PageSize = request.PageSize, QueryResult = transactions.Select(t => new TransactionResult(t.Id, t.WalletId, t.Price, t.Type.ToString(), t.Reason.ToString(), t.Description.ToString(), t.SourceWalletId, t.DestinationWalletId)).ToList() });
        }
    }
}
