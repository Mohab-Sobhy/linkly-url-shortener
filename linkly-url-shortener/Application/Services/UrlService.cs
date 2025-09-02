using linkly_url_shortener.Domain.Entities;
using linkly_url_shortener.Domain.Interfaces.Repositories;

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
}