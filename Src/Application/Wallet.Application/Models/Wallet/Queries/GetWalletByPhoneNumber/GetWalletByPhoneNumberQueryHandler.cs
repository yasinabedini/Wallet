using Framework.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet.Application.Models.Wallet.Queries.Common;
using Wallet.Domain.Models.Wallet.Repositories;

namespace Wallet.Application.Models.Wallet.Queries.GetWalletByPhoneNumber
{
    public class GetWalletByPhoneNumberQueryHandler : IQueryHandler<GetWalletByPhoneNumberQuery, PagedData<WalletResult>>
    {
        private readonly IWalletRepository _repository;

        public GetWalletByPhoneNumberQueryHandler(IWalletRepository repository)
        {
            _repository = repository;
        }

        public Task<PagedData<WalletResult>> Handle(GetWalletByPhoneNumberQuery request, CancellationToken cancellationToken)
        {
            var Wallets = _repository.GetList().Where(t => t.PhoneNumber.Value == request.PhoneNumber).Skip(request.SkipCount).Take(request.PageSize);
            return Task.FromResult(new PagedData<WalletResult> { QueryResult = Wallets.Select(t => new WalletResult(t.Id, t.WalletTitle.Value, t.PhoneNumber.Value, t.WalletBalance)).ToList(), PageNumber = request.PageNumber, PageSize = request.PageSize });
        }
    }
}
