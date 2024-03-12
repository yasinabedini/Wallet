using Framework.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet.Application.Models.Transaction.Queries.Common;
using Wallet.Application.Models.Transaction.Queries.GetTransactions;
using Wallet.Domain.Models.Transaction.Repositories;

namespace Wallet.Application.Models.Transaction.Queries.GetTransactionsByWalletId
{
    public class GetTransactionsByWalletIdQueryHandler : IQueryHandler<GetTransactionsByWalletIdQuery, PagedData<TransactionResult>>
    {
        private readonly ITransactionRepository _repository;

        public GetTransactionsByWalletIdQueryHandler(ITransactionRepository repository)
        {
            _repository = repository;
        }

        public Task<PagedData<TransactionResult>> Handle(GetTransactionsByWalletIdQuery request, CancellationToken cancellationToken)
        {
            var transactions = _repository.GetList().Where(t=>t.WalletId==request.WalletId).Skip(request.SkipCount).Take(request.PageSize).ToList();

            return Task.FromResult(new PagedData<TransactionResult> { PageNumber = request.PageNumber, PageSize = request.PageSize, QueryResult = transactions.Select(t => new TransactionResult(t.Id, t.WalletId, t.Price, t.Type.ToString(), t.Reason.ToString(), t.Description.ToString(), t.SourceWalletId, t.DestinationWalletId)).ToList() });
        }
    }
}
