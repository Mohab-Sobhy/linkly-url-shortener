using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using linkly_url_shortener.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace linkly_url_shortener.Models
{
    public class RegisterUserRepository : AbstractRepository<RegisterUser>
    {
        public RegisterUserRepository(ApplicationDBContext context) : base(context) { }
        public RegisterUser ReadByID(int id)
        {
            RegisterUser? user = _context.RegisterUsers.Find(id);
            if (user is null)
                throw new KeyNotFoundException($"RegisterUser with ID {id} not found.");
            return user;
        }
        public void Update(RegisterUser User)
        {
            var existingUser = ReadByID(User.Id);
            if (existingUser != null)
            {
                _context.Entry(existingUser).CurrentValues.SetValues(User);
                _context.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            RegisterUser User = ReadByID(id);
            if (User == null) throw new KeyNotFoundException();
            _context.RegisterUsers.Remove(User);
        }
    }
}