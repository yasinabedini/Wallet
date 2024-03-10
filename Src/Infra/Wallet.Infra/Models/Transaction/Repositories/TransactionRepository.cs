using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet.Domain.Models.Transaction.Entities;
using Wallet.Domain.Models.Transaction.Repositories;
using Wallet.Infra.Common.Repository;
using Wallet.Infra.Contexts;

namespace Wallet.Infra.Models.Transaction.Repositories;

public class TransactionRepository : BaseRepository<Domain.Models.Transaction.Entities.Transaction>, ITransactionRepository
{
    public TransactionRepository(WalletDbContext context) : base(context)
    {
    }
}
