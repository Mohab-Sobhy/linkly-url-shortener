using linkly_url_shortener.Application.DTO;
using linkly_url_shortener.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace linkly_url_shortener.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RegisterController : ControllerBase
{
    private readonly RegisterService _registerService;

    public RegisterController(RegisterService registerService)
    {
        _registerService = registerService;
    }
    
    [HttpPost("Register")]
    public async Task<IActionResult> Register([FromBody] CreateAccountRequestDTO request)
    {
        return Ok( await _registerService.CreateAccount(request) );
    }
}