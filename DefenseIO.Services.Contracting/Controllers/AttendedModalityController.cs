using DefenseIO.Domain.Domains.Contracting.Entities;
using DefenseIO.Domain.Domains.Users.Interfaces;
using DefenseIO.Infra.ApiConfig.Abstracts;
using DefenseIO.Infra.Shared.Notifications;
using DefenseIO.Services.Contracting.Commands.AttendedModality;
using DefenseIO.Services.Contracting.Queries.AttendedModalities;
using DefenseIO.Services.Contracting.Queries.Modality;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DefenseIO.Services.Contracting.Controllers
{
  [Route("attended-modalities")]
  [ApiController]
  [Authorize]
  public class AttendedModalityController : BaseApiController
  {
    public AttendedModalityController(IMediator mediator, NotificationContext notificationContext) : base(mediator, notificationContext)
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

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateProviderAttendedModality(
      [FromServices] ILoggedUserAcessor userLoggedAcessor,
      [FromRoute] Guid id,
      [FromBody] UpdateAttendedModalityCommand command)
    {
      var res = await _mediator.Send(command.ByProviderUserIdAndAttendedModalityId(userLoggedAcessor.UserId, id));

      return await ResponseOkIfNotExistsNotificationsAsync(res);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteProviderAttendedModality(
      [FromRoute] Guid id)
    {
      var res = await _mediator.Send(new DeleteAttendedModalityCommand(id));

      if (!res)
      {
        return await ResponseNotifications();
      }

      return await ResponseOkIfNotExistsNotificationsAsync();
    }

    [HttpGet("all/{type}")]
    public async Task<IActionResult> FindAttendedModalities(ModalityType type)
    {
      var res = await _mediator.Send(new FindAttendedModalitiesByTypeQuery()
      {
        Key = type
      });

      return await ResponseOkIfNotExistsNotificationsAsync(res);
    }

  }
}
