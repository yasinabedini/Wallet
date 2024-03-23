using Framework.Commands;
using Serilog;
using Wallet.Domain.Models.Transaction.Enums;
using Wallet.Domain.Models.Transaction.Repositories;
using Wallet.Domain.Models.Wallet.Repositories;

namespace Wallet.Application.Models.Wallet.Commands.BuyMobileRecharge
{
    public class BuyMobileRechargeCommandHandler : ICommandHandler<BuyMobileRechargeCommand, string>
    {
        private readonly IWalletRepository _repository;
        private readonly ITransactionRepository _transactionRepository;

        public BuyMobileRechargeCommandHandler(IWalletRepository repository, ITransactionRepository transactionRepository)
        {
            _repository = repository;
            _transactionRepository = transactionRepository;
        }

        public Task<string> Handle(BuyMobileRechargeCommand request, CancellationToken cancellationToken)
        {
            string message = $"The amount {request.RechargeAmount} was withdrawn from the wallet to the number {request.WalletId} for the purchase of SIM card recharge for {request.PhoneNumber}.";
            _transactionRepository.Add(new Domain.Models.Transaction.Entities.Transaction(request.WalletId, request.RechargeAmount, _TransactionType.Deposit_Money.ToString(), _TransactionReason.BuyMobileRecharge.ToString(), message,sourceWalletId:request.WalletId));
            _transactionRepository.Save();

            var wallet = _repository.GetById(request.WalletId);
            wallet.DecreaseWalletBalance(request.RechargeAmount);
            _repository.Update(wallet);
            _repository.Save();
            Log.Information(message);
            return Task.FromResult(message);
        }
    }
}
