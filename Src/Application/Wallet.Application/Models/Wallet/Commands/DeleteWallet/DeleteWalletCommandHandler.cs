using Framework.Commands;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet.Domain.Models.Wallet.Repositories;

namespace Wallet.Application.Models.Wallet.Commands.DeleteWallet
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
            Log.Information($"wallet by Id ({request.WalletId}) Deleted successfully.");
            return Task.CompletedTask;
        }
    }
}
