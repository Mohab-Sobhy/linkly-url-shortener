using linkly_url_shortener.Application.DTO;
using linkly_url_shortener.Application.Services;
using linkly_url_shortener.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace linkly_url_shortener.Presentation.Controllers;

[ApiController]
[Route("{shortCode}")]
public class RedirectionController : ControllerBase
{
    private readonly UrlService _urlService;
    private readonly LoggingService _loggingService;

    public RedirectionController(UrlService urlService, LoggingService loggingService)
    {
        _urlService = urlService;
        _loggingService = loggingService;
    }

    [HttpGet]
    public async Task<IActionResult> RedirectToUrl([FromRoute] string shortCode)
    {
        Url? url = await _urlService.GetlUrl(shortCode);
        if (url is null)
        {
            return NotFound();
        }

        LogVisitDto logVisit = new LogVisitDto
        {
            UrlId = url.Id,
            IpAddress = HttpContext.Connection.RemoteIpAddress!.ToString(),
            UserAgent = HttpContext.Request.Headers["User-Agent"].ToString(),
            Referer = HttpContext.Request.Headers["Referer"].ToString()
        };

        _loggingService.LogVisit(logVisit);

        return RedirectPermanent(url.OriginalUrl);
    }

}