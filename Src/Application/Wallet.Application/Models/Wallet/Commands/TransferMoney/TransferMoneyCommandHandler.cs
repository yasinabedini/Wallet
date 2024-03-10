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
        _sender.Send(new WithdrawFromWalletCommand(request.SourceWalletId, request.Amount));
        _sender.Send(new DepositToWalletCommand(request.DestinationWalletId, request.Amount));

        string message = $"The amount of {request.Amount} was withdrawn from wallet number {request.DestinationWalletId} and deposited into wallet number {request.SourceWalletId}.";
        return Task.FromResult(message);
    }    
}