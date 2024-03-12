using Framework.Commands;
using MediatR;
using Wallet.Application.Models.Wallet.Commands.RechargeWallet;
using Wallet.Application.Models.Wallet.Commands.WithdrawFromWallet;
using Wallet.Domain.Models.Transaction.Enums;
using Wallet.Domain.Models.Transaction.Repositories;
using Wallet.Domain.Models.Wallet.Repositories;

namespace Wallet.Application.Models.Wallet.Commands.TransferMoney;

public class TransferMoneyCommandHandler : ICommandHandler<TransferMoneyCommand, string>
{
    private readonly ITransactionRepository _transactionRepositoy;
    private readonly IWalletRepository _repository;

    public TransferMoneyCommandHandler(ITransactionRepository transactionRepositoy, IWalletRepository repository)
    {
        _transactionRepositoy = transactionRepositoy;
        _repository = repository;
    }


    public Task<string> Handle(TransferMoneyCommand request, CancellationToken cancellationToken)
    {
        int destinationAmount = request.DestinationWallets.Sum(t => t.Item2);
        _transactionRepositoy.Add(new Domain.Models.Transaction.Entities.Transaction(request.SourceWalletId, destinationAmount, _TransactionType.Withdraw_Money.ToString(), _TransactionReason.MoneyTransfer.ToString(), $"The amount of {destinationAmount} was withdrawn from the wallet to number {request.SourceWalletId} for Transafer Money for some Wallet.",sourceWalletId:request.SourceWalletId));
        _transactionRepositoy.Save();
        var sourceWallet = _repository.GetById(request.SourceWalletId);
        sourceWallet.DecreaseWalletBalance(destinationAmount);
        _repository.Save();

        foreach (var destinationWallet in request.DestinationWallets)
        {
            _transactionRepositoy.Add(new Domain.Models.Transaction.Entities.Transaction(destinationWallet.Item1, destinationWallet.Item2, _TransactionType.Deposit_Money.ToString(), _TransactionReason.DepositToWallet.ToString(), $"The amount of {destinationWallet.Item2} was Deposit to the wallet to number {destinationWallet.Item1}.",destinationWalletId:destinationWallet.Item1));
            _transactionRepositoy.Save();
            var destinationWalletModel = _repository.GetById(destinationWallet.Item1);
            destinationWalletModel.IncreaseWalletBalance(destinationWallet.Item2);            
            _repository.Save();
        }
        
        return Task.FromResult("The transfer was successful.");
    }    
}