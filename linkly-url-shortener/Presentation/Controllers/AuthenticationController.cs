using linkly_url_shortener.Application.DTO;
using linkly_url_shortener.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace linkly_url_shortener.Presentation.Controllers;

[ApiController]
[Route("api/")]
public class AuthenticationController : ControllerBase
{
    private readonly AuthenticationService _authenticationService;

    public AuthenticationController(AuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody] AuthenticateUserRequestDTO request)
    {
        string? token = await _authenticationService.AuthenticateAsync(request);
        if (token is null)
        {
            return Unauthorized( new { error = "Invalid credentials" } );
        }
        return Ok( token );
    }
}