using Microsoft.EntityFrameworkCore;
namespace linkly_url_shortener.Models
{
    public abstract class AbstractRepository<TEntity>
    where TEntity : class
    {
        protected readonly ApplicationDBContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public AbstractRepository(ApplicationDBContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }
        public void Create(TEntity item)
        {
            _dbSet.Add(item);
            Save();
        }
        public List<TEntity> ReadAll()
        {
            return _dbSet.ToList();
        }
        public void Save()
        {
            _context.SaveChanges();
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}