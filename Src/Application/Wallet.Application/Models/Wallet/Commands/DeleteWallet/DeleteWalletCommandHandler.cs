using Framework.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet.Domain.Models.Wallet.Repositories;

namespace Wallet.Application.Models.Wallet.Commands.AddWallet
{
    public class DeleteWalletCommandHandler : ICommandHandler<DeleteWalletCommand>
    {
        private readonly IWalletRepository _repository;

        public DeleteWalletCommandHandler(IWalletRepository repository)
        {
            _repository = repository;
        }

        public Task Handle(DeleteWalletCommand request, CancellationToken cancellationToken)
        {
            _repository.Delete(request.WalletId);
            _repository.Save();

            return Task.CompletedTask;
        }
    }
}
