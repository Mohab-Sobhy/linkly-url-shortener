using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using linkly_url_shortener.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace linkly_url_shortener.Models
{
    public class GuestUserRepository : AbstractRepository<GuestUser>
    {
        public GuestUserRepository(ApplicationDBContext context) : base(context) { }
        public GuestUser ReadByID(int id)
        {
            GuestUser? user = _context.GuestUsers.Find(id);
            if (user is null)
                throw new KeyNotFoundException($"GuestUser with ID {id} not found.");
            return user;
        }
        public void Update(GuestUser Item)
        {
            var existingItem = ReadByID(Item.Id);
            if (existingItem != null)
            {
                _context.Entry(existingItem).CurrentValues.SetValues(Item);
                _context.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            GuestUser Item = ReadByID(id);
            if (Item == null) throw new KeyNotFoundException();
            _context.GuestUsers.Remove(Item);
        }
    }
}