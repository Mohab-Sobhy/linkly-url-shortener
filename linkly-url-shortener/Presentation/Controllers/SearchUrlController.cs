using System.Security.Claims;
using linkly_url_shortener.Application.Services;
using linkly_url_shortener.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace linkly_url_shortener.Presentation.Controllers;

[ApiController]
[Route("api/")]
public class SearchUrlController : ControllerBase
{
    private readonly UrlService _urlService;
    public SearchUrlController(UrlService urlService)
    {
        _urlService = urlService;
    }
    
    [HttpGet("SearchUrl")]
    [Authorize]
    public async Task<IActionResult> SearchUrl([FromQuery]string url, [FromQuery]int pageNumber, [FromQuery]int pageSize)
    {
        var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (string.IsNullOrEmpty(userIdClaim))
            return Unauthorized();

        var userId = int.Parse(userIdClaim);

        var result = await _urlService.GetlUrlsByUserAsync(userId, url, pageNumber, pageSize);

        return Ok(result);
    }
}