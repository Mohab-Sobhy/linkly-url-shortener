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
        public void Update(GuestUser Guest)
        {
            var existingGuest = _context.GuestUsers
                .Include(u => u.URLs)
                .FirstOrDefault(u => u.Id == Guest.Id);
            if (existingGuest != null)
            {
                if (existingGuest.URLs != null)
                {
                    existingGuest.URLs.Clear();
                    foreach (var url in existingGuest.URLs)
                    {
                        existingGuest.URLs.Add(url);
                    }
                }
                _context.Entry(existingGuest).CurrentValues.SetValues(Guest);
                _context.SaveChanges();
                Console.WriteLine($"Guest user with id {Guest.GetId()} updated");
            }
        }
        public void Delete(int id)
        {
            GuestUser Item = ReadByID(id);
            if (Item == null) throw new KeyNotFoundException();
            _context.GuestUsers.Remove(Item);
            Console.WriteLine($"Guest user with id {id} deleted");
        }
    }
}