using Framework.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet.Domain.Common.Repositories;
using Wallet.Domain.Models.Transaction.Enums;
using Wallet.Domain.Models.Transaction.Repositories;
using Wallet.Domain.Models.Wallet.Repositories;

namespace Wallet.Application.Models.Wallet.Commands.PayingBill
{
    public class PayingBillCommandHandler : ICommandHandler<PayingBillCommand, string>
    {
        private readonly IWalletRepository _repository;
        private readonly ITransactionRepository _transactionRepository;

        public PayingBillCommandHandler(IWalletRepository repository, ITransactionRepository transactionRepository)
        {
            _repository = repository;
            _transactionRepository = transactionRepository;
        }

        public Task<string> Handle(PayingBillCommand request, CancellationToken cancellationToken)
        {
            string message = $"The amount {request.BillAmount} was withdrawn from the wallet to the number {request.WalletId} to pay {request.BillTitle}'s bill.";
            _transactionRepository.Add(new Domain.Models.Transaction.Entities.Transaction(request.WalletId, request.BillAmount, _TransactionType.Withdraw_Money.ToString(), _TransactionReason.PayingBill.ToString(), message,sourceWalletId: request.WalletId));
            _transactionRepository.Save();

            var wallet = _repository.GetById(request.WalletId);
            wallet.DecreaseWalletBalance(request.BillAmount);
            _repository.Update(wallet);
            _repository.Save();

            return Task.FromResult(message);
        }
    }
}
