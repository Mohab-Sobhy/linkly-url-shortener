using linkly_url_shortener.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace linkly_url_shortener.Models
{
    public class RegisterUserRepository : AbstractRepository<RegisterUser>
    {
        public RegisterUserRepository(ApplicationDBContext context) : base(context) { }
        public List<RegisterUser> Read()
        {
            return _context.RegisterUsers.Include(b => b.URLs).ToList();
        }
        public RegisterUser ReadByID(int id)
        {
            RegisterUser? user = _context.RegisterUsers.Find(id);
            if (user is null)
                throw new KeyNotFoundException($"RegisterUser with ID {id} not found.");
            return user;
        }
        public void Update(RegisterUser User)
        {
            var existingUser = _context.RegisterUsers
                .Include(u => u.URLs)
                .FirstOrDefault(u => u.Id == User.Id);
            if (existingUser != null)
            {
                if (existingUser.URLs != null)
                {
                    existingUser.URLs.Clear();
                    foreach (var url in existingUser.URLs)
                    {
                        existingUser.URLs.Add(url);
                    }
                }
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