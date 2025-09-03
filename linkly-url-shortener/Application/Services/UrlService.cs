using linkly_url_shortener.Application.DTO;
using linkly_url_shortener.Domain.Entities;
using linkly_url_shortener.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace linkly_url_shortener.Application.Services;

public class UrlService
{
    private IUrlRepository _urlRepository;

    public UrlService(IUrlRepository urlRepository)
    {
        _urlRepository = urlRepository;
    }
    
    public async Task<Url?> GetlUrl(string? shortCode)
    {
        const int ShortCodeLength = 4;
        
        if (shortCode?.Length != ShortCodeLength)
            return null;

        var url = await _urlRepository.GetByShortCode(shortCode);
        
        if(url is null || url.IsActive is false)
            return null;
        
        return url;
    }

    public async Task< PagedResultDTO<Url> > GetlUrlsByUserAsync(int userId, string? searchUrl, int pageNumber, int pageSize)
    {
        var query = _urlRepository.GetByUser(userId);

        if (!string.IsNullOrWhiteSpace(searchUrl))
        {
            query = query.Where( u => u.OriginalUrl.Contains(searchUrl) );
        }

        var totalCount = await query.CountAsync();
        
        var items = await query
            .OrderByDescending(u => u.Id)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return new PagedResultDTO<Url>
        {
            Items = items,
            TotalCount = totalCount,
            PageNumber = pageNumber,
            PageSize = pageSize
        };
    }
}