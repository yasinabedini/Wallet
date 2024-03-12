using Framework.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet.Application.Models.Wallet.Commands.DisActivateWallet;
using Wallet.Domain.Models.Wallet.Repositories;

namespace Wallet.Application.Models.Wallet.Commands.ActivateWallet;

public class ActivateWalletCommandHandler : ICommandHandler<ActivateWalletCommand>
{
    private readonly IWalletRepository _repository;

    public ActivateWalletCommandHandler(IWalletRepository repository)
    {
        _repository = repository;
    }

    public Task Handle(ActivateWalletCommand request, CancellationToken cancellationToken)
    {
        var wallet = _repository.GetById(request.WalletId);
        wallet.Activate();
        _repository.Update(wallet);
        _repository.Save();

        return Task.CompletedTask;
    }
}