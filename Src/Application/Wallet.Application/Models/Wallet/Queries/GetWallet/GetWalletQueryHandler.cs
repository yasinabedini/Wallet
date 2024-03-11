using Framework.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet.Application.Models.Wallet.Queries.Common;
using Wallet.Domain.Models.Wallet.Repositories;

namespace Wallet.Application.Models.Wallet.Queries.GetWallet
{
    public class GetWalletQueryHandler : IQueryHandler<GetWalletQuery, WalletResult>
    {
        private readonly IWalletRepository _repository;

        public GetWalletQueryHandler(IWalletRepository repository)
        {
            _repository = repository;
        }

        public  Task<WalletResult> Handle(GetWalletQuery request, CancellationToken cancellationToken)
        {
            var wallet = _repository.GetById(request.Id);

            return Task.FromResult(new WalletResult(wallet.Id, wallet.WalletTitle.Value, wallet.PhoneNumber.Value, wallet.WalletBalance));
        }
    }
}
