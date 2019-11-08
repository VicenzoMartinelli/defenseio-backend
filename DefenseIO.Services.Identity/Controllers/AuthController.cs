using DefenseIO.Domain.Domains.Users;
using DefenseIO.Infra.ApiConfig.Abstracts;
using DefenseIO.Infra.Shared.Notifications;
using DefenseIO.Services.Identity.Commands.Registrer;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DefenseIO.Services.Identity.Controllers
{
  [Route("auth")]
  [ApiController]
  public class AuthController : BaseApiController
  {
    public AuthController(IMediator mediator, NotificationContext notificationContext) : base(mediator, notificationContext)
    {
    }

    [HttpPost("{type}/register")]
    public async Task<IActionResult> Registrer(UserType type, RegisterUserCommand command)
    {
      var res = await _mediator.Send(command.SetType(type));

      if (!res.IsSuccess)
      {
        return await ResponseNotifications();
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
  }
}
