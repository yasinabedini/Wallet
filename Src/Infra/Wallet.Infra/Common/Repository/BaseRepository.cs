using Framework.Entities;
using Wallet.Domain.Common.Repositories;
using Wallet.Infra.Contexts;

namespace Wallet.Infra.Common.Repository
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : AggregateRoot
    {
        private readonly WalletDbContext _context;

        public BaseRepository(WalletDbContext context)
        {
            _context = context;
        }

        public void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }

        public void Delete(long id)
        {
            var entity = _context.Set<TEntity>().Find(id);
            entity.IsDelete = true;
            Update(entity);
        }

        public TEntity GetById(long id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public List<TEntity> GetList()
        {
            return _context.Set<TEntity>().ToList();
        }

        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
