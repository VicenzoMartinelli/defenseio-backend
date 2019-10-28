using DefenseIO.Domain.Domains.Users.Interfaces;
using DefenseIO.Infra.ApiConfig.Abstracts;
using DefenseIO.Infra.Shared.Notifications;
using DefenseIO.Services.Contracting.Commands.AttendedModality;
using DefenseIO.Services.Contracting.Queries.Modality;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DefenseIO.Services.Contracting.Controllers
{
  [Route("attended-modalities")]
  [ApiController]
  [Authorize]
  public class AttendedModality : BaseApiController
  {
    public AttendedModality(IMediator mediator, NotificationContext notificationContext) : base(mediator, notificationContext)
    { }

    [HttpGet()]
    public async Task<IActionResult> FindProviderAttendedModalities([FromServices] ILoggedUserAcessor userLoggedAcessor)
    {
      var res = await _mediator.Send(new FindProviderAttendedModalitiesQuery(userLoggedAcessor.UserId));

      return await ResponseOkIfNotExistsNotificationsAsync(res);
    }

    [HttpPost()]
    public async Task<IActionResult> CreateProviderAttendedModality(
      [FromServices] ILoggedUserAcessor userLoggedAcessor,
      [FromBody] CreateAttendedModalityCommand command)
    {
      var res = await _mediator.Send(command.ByProviderUserId(userLoggedAcessor.UserId));

      return await ResponseOkIfNotExistsNotificationsAsync(res);
    }
  }
}
