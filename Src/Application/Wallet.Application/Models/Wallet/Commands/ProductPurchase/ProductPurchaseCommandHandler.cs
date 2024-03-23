using Framework.Commands;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet.Domain.Common.Repositories;
using Wallet.Domain.Models.Transaction.Enums;
using Wallet.Domain.Models.Transaction.Repositories;
using Wallet.Domain.Models.Wallet.Repositories;

namespace Wallet.Application.Models.Wallet.Commands.ProductPurchase
{
    public class ProductPurchaseCommandHandler : ICommandHandler<ProductPurchaseCommand, string>
    {
        private readonly IWalletRepository _repository;
        private readonly ITransactionRepository _transactionRepository;

        public ProductPurchaseCommandHandler(IWalletRepository repository, ITransactionRepository transactionRepository)
        {
            _repository = repository;
            _transactionRepository = transactionRepository;
        }

        public Task<string> Handle(ProductPurchaseCommand request, CancellationToken cancellationToken)
        {
            string message = $"The amount {request.Amount} was withdrawn from the wallet to the number {request.WalletId} for the purchase of goods.";
            _transactionRepository.Add(new Domain.Models.Transaction.Entities.Transaction(request.WalletId, request.Amount, _TransactionType.Withdraw_Money.ToString(), _TransactionReason.CashWithdrawal.ToString(), message,sourceWalletId: request.WalletId));
            _transactionRepository.Save();

            var wallet = _repository.GetById(request.WalletId);
            wallet.DecreaseWalletBalance(request.Amount);
            _repository.Update(wallet);
            _repository.Save();
            Log.Information(message);
            return Task.FromResult(message);
        }
    }
}
