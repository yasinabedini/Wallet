using Framework.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Wallet.Domain.Models.Wallet.Repositories;

namespace Wallet.Application.Models.Wallet.Commands.DisActivateWallet
{
    public class DisActivateWalletCommandHandler : ICommandHandler<DisActivateWalletCommand>
    {
        private readonly IWalletRepository _repository;

        public DisActivateWalletCommandHandler(IWalletRepository repository)
        {
            _repository = repository;
        }

        public Task Handle(DisActivateWalletCommand request, CancellationToken cancellationToken)
        {
            var wallet = _repository.GetById(request.WalletId);
            wallet.DisActivate();
            _repository.Update(wallet);
            _repository.Save();

            return Task.CompletedTask;
        }
    }
}
