using DefenseIO.Domain.Domains.Users.Interfaces;
using DefenseIO.Infra.ApiConfig.Abstracts;
using DefenseIO.Infra.Shared.Notifications;
using DefenseIO.Services.Contracting.Commands.Solicitations.Create;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DefenseIO.Services.Contracting.Controllers
{
  [Route("solicitations")]
  [ApiController]
  [Authorize]
  public class SolicitationController : BaseApiController
  {
    public SolicitationController(IMediator mediator, NotificationContext notificationContext) : base(mediator, notificationContext)
    { }

    [HttpPost]
    public async Task<IActionResult> UpdateProviderAttendedModality(
      [FromServices] ILoggedUserAcessor userLoggedAcessor,
      [FromBody] CreateSolicitationCommand command)
    {
      var res = await _mediator.Send(command.ByClient(userLoggedAcessor.UserId));

      return await ResponseOkIfNotExistsNotificationsAsync(res);
    }

  }
}
