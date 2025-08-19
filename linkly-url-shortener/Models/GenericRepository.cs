using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using linkly_url_shortener.Models;
using linkly_url_shortener.Domain.Entities;
namespace linkly_url_shortener.Models
{
    public class GenericRepository<TEntity, TKey>:AbstractRepository<TEntity>
    where TEntity : class, Identifiable<TKey>
    {

        public GenericRepository(ApplicationDBContext context):base(context)
        {
        }
        public TEntity ReadByID(TKey id)
    {
        var entity = _dbSet.Find(id);
        if (entity is null)
            throw new KeyNotFoundException($"{typeof(TEntity).Name} with ID {id} not found.");
        return entity;
    }
        public void Update(TEntity Item)
        {
            var existingItem = ReadByID(Item.Id);
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