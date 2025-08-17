using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace linkly_url_shortener.Models
{
    public class GuestUserRepository : IDisposable
    {
        private ApplicationDBContext _context;
        public GuestUserRepository(ApplicationDBContext context)
        {
            this._context = context;
        }
        public void Create(GuestUser item)
        {
            _context.Add(item);
            _context.SaveChanges();
        }
        public List<GuestUser> Read()
        {
            return _context.GuestUsers.ToList();
        }
        public Blog ReadByID(int id)
        {
            return _context.GuestUsers.Find(id);
        }
        public void Update(GuestUser guest)
        {
            var existingBlog = _context.GuestUsers
                .FirstOrDefault(g => g.Id == guest.Id);
            if (existingBlog != null)
            {
                _context.Entry(existingBlog).CurrentValues.SetValues(blog);
                existingBlog.Tags.Clear();
                foreach (var tag in blog.Tags)
                {
                    existingBlog.Tags.Add(tag);
                }
                _context.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            Blog blog = _context.Blogs.Find(id);
            if (blog == null) throw new KeyNotFoundException();
            _context.Blogs.Remove(blog);
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