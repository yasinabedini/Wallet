using Framework.Commands;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet.Domain.Models.Wallet.Repositories;

namespace Wallet.Application.Models.Wallet.Commands.CheckWalletAvailability
{
    public class CheckWalletAvailabilityCommandHandler : ICommandHandler<CheckWalletAvailabilityCommand, bool>
    {
        private readonly IWalletRepository _repository;

        public CheckWalletAvailabilityCommandHandler(IWalletRepository repository)
        {
            _repository = repository;
        }

        public Task<bool> Handle(CheckWalletAvailabilityCommand request, CancellationToken cancellationToken)
        {
            var wallet = _repository.GetById(request.Id);
            Log.Information($"The availability wallet ({request.Id}) was checked");
            if (wallet is null) return Task.FromResult(false);
            
            else return Task.FromResult(true);
        }
    }
}
