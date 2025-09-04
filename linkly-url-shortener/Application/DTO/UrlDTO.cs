using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace linkly_url_shortener.Application.DTO
{
    public class UrlDTO
    {
        public required string OriginalUrl { get; set; }
        public required string ShortCode { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; }
        public bool IsCustomName { get; set; }
        public int userId;
        public bool IsGuest;
    }
}
