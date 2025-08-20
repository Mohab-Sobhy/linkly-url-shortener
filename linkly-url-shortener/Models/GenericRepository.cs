using linkly_url_shortener.Domain.Entities;
namespace linkly_url_shortener.Models
{
    public class GenericRepository<TEntity, TKey>:AbstractRepository<TEntity>
    where TEntity : IdentifiableEntity<TKey>
    {

        public GenericRepository(ApplicationDBContext context):base(context)
        {
        }
        public TEntity ReadByID(TKey? id)
        {
            var entity = _dbSet.Find(id);
            if (entity is null)
                throw new KeyNotFoundException($"{typeof(TEntity).Name} with ID {id} not found.");
            return entity;
        }
        public void Update(TEntity Item)
        {
            TKey? id = Item.GetId();
            TEntity existingItem = ReadByID(id);
            if (existingItem != null)
            {
                _context.Entry(existingItem).CurrentValues.SetValues(Item);
                _context.SaveChanges();
            }
        }
        public void Delete(TKey id)
        {
            TEntity Item = ReadByID(id);
            if (Item == null) throw new KeyNotFoundException();
            _dbSet.Remove(Item);
        }
    }
}