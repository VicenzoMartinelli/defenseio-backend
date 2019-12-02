using DefenseIO.Domain.Domains.Contracting.Entities.Solicitation;
using DefenseIO.Domain.Domains.Users;
using DefenseIO.Domain.Domains.Users.Interfaces;
using DefenseIO.Infra.ApiConfig.Abstracts;
using DefenseIO.Infra.Shared.Notifications;
using DefenseIO.Services.Contracting.Commands.Solicitations.Create;
using DefenseIO.Services.Contracting.Queries.Solicitations;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DefenseIO.Services.Contracting.Controllers
{
  [Route("solicitations")]
  [ApiController]
  [Authorize]
  public class SolicitationController : BaseApiController
  {
    private readonly ILoggedUserAcessor _userLoggedAccessor;

    public SolicitationController(IMediator mediator, ILoggedUserAcessor userLoggedAcessor, NotificationContext notificationContext) : base(mediator, notificationContext)
    {
      _userLoggedAccessor = userLoggedAcessor;
    }

    [HttpPost]
    public async Task<IActionResult> CreateSolicitation([FromBody] CreateSolicitationCommand command)
    {
      var res = await _mediator.Send(command.ByClient(_userLoggedAccessor.UserId));

      return await ResponseOkIfNotExistsNotificationsAsync(res);
    }

    [HttpPut("{id}/accept")]
    public async Task<IActionResult> AcceptSolicitation([FromRoute] string id, [FromBody] AcceptSolicitationCommand command)
    {
      var res = await _mediator.Send(command.SetId(id).ByProvider(_userLoggedAccessor.UserId));

      return await ResponseOkIfNotExistsNotificationsAsync(res);
    }

    [HttpPut("{id}/recuse")]
    public async Task<IActionResult> RecuseSolicitation([FromRoute] string id)
    {
      var res = await _mediator.Send(new RecuseSolicitationCommand().SetId(id).ByProvider(_userLoggedAccessor.UserId));

      return await ResponseOkIfNotExistsNotificationsAsync(res);
    }

    [HttpGet("created")]
    public async Task<IActionResult> GetOpenedSolicitations()
    {
      var res = default(object);

      if (_userLoggedAccessor.Type == UserType.Provider)
      {
        res = await _mediator.Send(new FindOpenedSolicitationsByProviderQuery(_userLoggedAccessor.UserId));
      }
      else
      {
        res = await _mediator.Send(new FindOpenedSolicitationsByClientQuery(_userLoggedAccessor.UserId, SolicitationStatus.Created));
      }

      return await ResponseOkIfNotExistsNotificationsAsync(res);
    }

    [HttpGet("in-progress")]
    public async Task<IActionResult> GetCurrentSolicitations()
    {
      var res = await _mediator.Send(new FindOpenedSolicitationsByClientQuery(_userLoggedAccessor.UserId, SolicitationStatus.Accepted));

      return await ResponseOkIfNotExistsNotificationsAsync(res);
    }

    [HttpPut("{id:guid}/finish")]
    public async Task<IActionResult> FinishSolicitation([FromRoute] Guid id, [FromBody] FinishSolicitationCommand command)
    {
      var res = await _mediator.Send(command.SetId(id));

      return await ResponseOkIfNotExistsNotificationsAsync(res);
    }
  }
}
