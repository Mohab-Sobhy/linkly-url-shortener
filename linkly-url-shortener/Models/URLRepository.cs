using linkly_url_shortener.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace linkly_url_shortener.Models
{
    public class URLRepository : AbstractRepository<GuestUser>
    {
        public URLRepository(ApplicationDBContext context) : base(context) { }
        public URL ReadByID(int id)
        {
            URL? url = _context.URLs.Find(id);
            if (url is null)
                throw new KeyNotFoundException($"GuestUser with ID {id} not found.");
            return url;
        }
        public void Update(URL Url)
        {
            var existingURL = _context.URLs
                .Include(l => l.VisitLogs)
                .FirstOrDefault(url => url.Id == Url.Id);
            if (existingURL != null)
            {
                if (existingURL.VisitLogs != null)
                {
                    existingURL.VisitLogs.Clear();
                    foreach (var url in existingURL.VisitLogs)
                    {
                        existingURL.VisitLogs.Add(url);
                    }
                }
                _context.Entry(existingURL).CurrentValues.SetValues(Url);
                _context.SaveChanges();
                Console.WriteLine($"Guest user with id {Url.GetId()} updated");
            }
        }
        public void Delete(int id)
        {
            URL url = ReadByID(id);
            if (url == null) throw new KeyNotFoundException();
            _context.URLs.Remove(url);
            Console.WriteLine($"Guest user with id {id} deleted");
        }
    }
}