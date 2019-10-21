using DefenseIO.Domain.Domains.Users;
using DefenseIO.Services.Identity.Commands.Registrer;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DefenseIO.Services.Identity.Controllers
{
  [Route("auth")]
  [ApiController]
  public class AuthController : ControllerBase
  {
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
      _mediator = mediator;
    }

    [HttpPost("{type}/register")]
    public async Task<IActionResult> Registrer(UserType type, RegisterUserCommand command)
    {
      var res = await _mediator.Send(command.SetType(type));

      if (!res.IsSuccess)
      {
        return BadRequest();
      }

      return Ok(res);
    }

    [HttpPost("sign-in")]
    public async Task<IActionResult> SignIn(LoginCommand command)
    {
      var res = await _mediator.Send(command);

      if (!res.IsSuccess)
      {
        return BadRequest();
      }

      return Ok(res);
    }

    [HttpGet("teste")]
    public IActionResult Get()
    {
      return Ok("ADSADA");
    }
  }
}
