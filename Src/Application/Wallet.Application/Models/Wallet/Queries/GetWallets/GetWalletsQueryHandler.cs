using Framework.Queries;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet.Application.Models.Wallet.Queries.Common;
using Wallet.Domain.Models.Wallet.Repositories;

namespace Wallet.Application.Models.Wallet.Queries.GetWallets
{
    internal class GetWalletsQueryHandler : IQueryHandler<GetWalletsQuery, PagedData<WalletResult>>
    {
        private readonly IWalletRepository _repository;

        public GetWalletsQueryHandler(IWalletRepository repository)
        {
            _repository = repository;
        }

        public Task<PagedData<WalletResult>> Handle(GetWalletsQuery request, CancellationToken cancellationToken)
        {
            var Wallets = _repository.GetList().Skip(request.SkipCount).Take(request.PageSize);
            Log.Information("List of wallets successfully retrieved");
            return Task.FromResult(new PagedData<WalletResult> { QueryResult = Wallets.Select(t => new WalletResult(t.Id, t.WalletTitle.Value, t.PhoneNumber.Value, t.WalletBalance)).ToList(), PageNumber = request.PageNumber, PageSize = request.PageSize });
        }
    }
}
