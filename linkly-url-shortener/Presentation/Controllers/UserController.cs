using linkly_url_shortener.Application;
using linkly_url_shortener.Application.DTO;
using Microsoft.AspNetCore.Mvc;

namespace linkly_url_shortener.Controllers;

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
    public IActionResult Register(CreateAccountRequestDTO request)
    {
        _userService.CreateAccount(request);
        return Ok();
    }
}