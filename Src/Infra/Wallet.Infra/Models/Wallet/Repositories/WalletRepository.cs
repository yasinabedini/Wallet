using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet.Domain.Models.Wallet.Repositories;
using Wallet.Infra.Common.Repository;
using Wallet.Infra.Contexts;

namespace Wallet.Infra.Models.Wallet.Repositories
{
    public class WalletRepository : BaseRepository<Domain.Models.Wallet.Entities.Wallet>, IWalletRepository
    {
        public WalletRepository(WalletDbContext context) : base(context)
        {
        }
    }
}
