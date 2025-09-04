using linkly_url_shortener.Application.DTO;
using linkly_url_shortener.Domain.Entities;
using linkly_url_shortener.Domain.Interfaces.Repositories;
using linkly_url_shortener.Infrastructure.Cryptography;
using linkly_url_shortener.Infrastructure.Database.Repositories;
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

        if (url is null || url.IsActive is false)
            return null;

        return url;
    }
    public async Task CreateUrl(UrlDTO requestDto, String? CustomName = null)
    {
        DateTime timeStamp = DateTime.Now;
        Url newUrl = new Url()
        {
            OriginalUrl = requestDto.OriginalUrl,
            ShortCode = "",
            CreatedAt = timeStamp,
            UpdatedAt = timeStamp,
            IsActive = true
        };
        if (CustomName != null)
        {
            newUrl.IsCustomName = true;
            newUrl.ShortCode = CustomName;
        }
        else
        {
            newUrl.IsCustomName = false;
            newUrl.ShortCode = makeShortCode(requestDto.OriginalUrl, timeStamp, 8);
        }
        await _urlRepository.AddAsync(newUrl);
    }
    private String makeShortCode(String OriginalUrl, DateTime timeStamp, int n)
    {
        byte[] hashedBytes = StringHasher.GetMd5Hash(OriginalUrl + timeStamp.ToString());
        byte[] hex8Bytes = new byte[n];
        for (int i = 0; i < n; i++)
        {
            hex8Bytes[i] = hashedBytes[i];
        }
        String bytes62 = ConvertBase16ToBase62(hex8Bytes,n);
        return bytes62;
    }
    public static String ConvertBase16ToBase62(byte[] sb, int n)
    {
        if (sb.Length != 8) throw new Exception("In Method ConvertBase16ToBase62, byte array does not match the size given");//?
        byte[] conv = new byte[n];
        String result = "";
        foreach (Byte b in sb)
        {
            String byteResult = "";
            decimal a = b;
            do
            {
                decimal mod = a % 62;
                a /= 62;
                a = Math.Floor(a);
                if (mod < 10)
                {
                    byteResult = mod.ToString() + byteResult;
                }
                else if (mod > 35)
                {
                    char letter = 'a';
                    letter = (char)(letter + (mod - 36));
                    byteResult = letter + byteResult;
                }
                else
                {
                    char letter = 'A';
                    letter = (char)(letter + (mod - 10));
                    byteResult = letter + byteResult;
                }
            } while (a != 0);
            if (b < 62)
            {
                byteResult = '0'+byteResult;
            }
            result += byteResult;
        }
        return result;
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