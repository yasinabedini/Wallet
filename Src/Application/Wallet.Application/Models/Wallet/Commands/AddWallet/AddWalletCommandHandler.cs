using Framework.Commands;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet.Domain.Models.Wallet.Repositories;

namespace Wallet.Application.Models.Wallet.Commands.AddWallet
{
    public class AddWalletCommandHandler : ICommandHandler<AddWalletCommand>
    {
        private readonly IWalletRepository _repository;

        public AddWalletCommandHandler(IWalletRepository repository)
        {
            _repository = repository;
        }

        public Task Handle(AddWalletCommand request, CancellationToken cancellationToken)
        {
            _repository.Add(new Domain.Models.Wallet.Entities.Wallet(request.Title, request.PhoneNumber));
            _repository.Save();
            Log.Information($"a wallet created successfully for this phonenumber ({request.PhoneNumber})");
            return Task.CompletedTask;
        }
    }
}
