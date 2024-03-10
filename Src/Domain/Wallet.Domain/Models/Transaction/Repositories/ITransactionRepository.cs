using Wallet.Domain.Common.Repositories;

namespace Wallet.Domain.Models.Transaction.Repositories;

public interface ITransactionRepository:IRepository<Entities.Transaction>
{
}
