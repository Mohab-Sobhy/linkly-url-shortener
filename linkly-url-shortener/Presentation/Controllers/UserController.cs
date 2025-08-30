using linkly_url_shortener.Application.DTO;
using linkly_url_shortener.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace linkly_url_shortener.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly UserService _userService;

    public UserController(UserService userService)
    {
        _userService = userService;
    }
    
    [HttpPost("Register")]
    public async Task<IActionResult> Register(CreateAccountRequestDTO request)
    {
        return Ok( await _userService.CreateAccount(request) );
    }
}