using Framework.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet.Application.Models.Wallet.Commands.DepositToWallet;
using Wallet.Domain.Models.Transaction.Repositories;
using Wallet.Domain.Models.Wallet.Repositories;

namespace Wallet.Application.Models.Wallet.Commands.WithdrawFromWallet
{
    public class WithdrawFromWalletCommandHandler : ICommandHandler<WithdrawFromWalletCommand, string>
    {
        private readonly IWalletRepository _repository;
        private readonly ITransactionRepository _transactionRepository;

        public WithdrawFromWalletCommandHandler(IWalletRepository repository, ITransactionRepository transactionRepository)
        {
            _repository = repository;
            _transactionRepository = transactionRepository;
        }

        public Task<string> Handle(WithdrawFromWalletCommand request, CancellationToken cancellationToken)
        {
            string message = $"The amount of {request.Amount} was withdrawn from the wallet to number {request.WalletId}.";
            _transactionRepository.Add(new Domain.Models.Transaction.Entities.Transaction(request.WalletId, request.Amount, 2, message));
            _transactionRepository.Save();

            var wallet = _repository.GetById(request.WalletId);
            wallet.DecreaseWalletBalance(request.Amount);
            _repository.Update(wallet);
            _repository.Save();

            return Task.FromResult(message);
        }
    }
}
