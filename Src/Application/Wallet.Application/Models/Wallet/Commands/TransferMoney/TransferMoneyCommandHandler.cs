using Framework.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet.Application.Models.Wallet.Commands.DepositToWallet;
using Wallet.Application.Models.Wallet.Commands.WithdrawFromWallet;

namespace Wallet.Application.Models.Wallet.Commands.TransferMoney;

public class TransferMoneyCommandHandler : ICommandHandler<TransferMoneyCommand, string>
{
    private readonly ISender _sender;

    public TransferMoneyCommandHandler(ISender sender)
    {
        _sender = sender;
    }

    public Task<string> Handle(TransferMoneyCommand request, CancellationToken cancellationToken)
    {
        _sender.Send(new WithdrawFromWalletCommand(request.SourceWalletId, request.DestinationWallets.Sum(t=>t.Item2)));
        foreach (var destinationWallet in request.DestinationWallets)
        {
            _sender.Send(new DepositToWalletCommand(destinationWallet.Item1, destinationWallet.Item2));
        }
        
        return Task.FromResult("The transfer was successful.");
    }    
}