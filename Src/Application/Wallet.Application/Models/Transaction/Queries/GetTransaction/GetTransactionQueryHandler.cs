using Framework.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Wallet.Application.Models.Transaction.Queries.Common;
using Wallet.Domain.Models.Transaction.Repositories;

namespace Wallet.Application.Models.Transaction.Queries.GetTransaction
{
    public class GetTransactionQueryHandler : IQueryHandler<GetTransactionQuery, TransactionResult>
    {
        private readonly ITransactionRepository _repository;

        public GetTransactionQueryHandler(ITransactionRepository repository)
        {
            _repository = repository;
        }

        public Task<TransactionResult> Handle(GetTransactionQuery request, CancellationToken cancellationToken)
        {
            var transaction = _repository.GetById(request.Id);

            return Task.FromResult(new TransactionResult(transaction.Id, transaction.WalletId, transaction.Price, transaction.Type.Value, transaction.Reason.Value, transaction.Description.Value, transaction.SourceWalletId, transaction.DestinationWalletId));
        }
    }
}
