using Framework.Commands;
using Serilog;
using Wallet.Domain.Models.Wallet.Repositories;

namespace Wallet.Application.Models.Wallet.Commands.CheckWalletBalance;

public class CheckWalletBalanceCommandHandler : ICommandHandler<CheckWalletBalanceCommand, bool>
{
    private readonly IWalletRepository _repository;

    public CheckWalletBalanceCommandHandler(IWalletRepository repository)
    {
        _repository = repository;
    }

    public Task<bool> Handle(CheckWalletBalanceCommand request, CancellationToken cancellationToken)
    {
        var wallet = _repository.GetById(request.WalletId);
        Log.Information($"The balance wallet ({request.WalletId}) was checked");
        if (wallet.WalletBalance >= request.RequestedAmount) return Task.FromResult(true);
        else return Task.FromResult(false);
    }
}
