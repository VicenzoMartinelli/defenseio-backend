using DefenseIO.Domain.Domains.Users.Interfaces;
using DefenseIO.Infra.ApiConfig.Abstracts;
using DefenseIO.Infra.Shared.Notifications;
using DefenseIO.Services.Contracting.Commands.Solicitations.Create;
using DefenseIO.Services.Contracting.Queries.Solicitations;
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
    private readonly ILoggedUserAcessor _userLoggedAcessor;

    public SolicitationController(IMediator mediator, ILoggedUserAcessor userLoggedAcessor, NotificationContext notificationContext) : base(mediator, notificationContext)
    {
      _userLoggedAcessor = userLoggedAcessor;
    }

    [HttpPost]
    public async Task<IActionResult> CreateSolicitation([FromBody] CreateSolicitationCommand command)
    {
      var res = await _mediator.Send(command.ByClient(_userLoggedAcessor.UserId));

      return await ResponseOkIfNotExistsNotificationsAsync(res);
    }

    [HttpPut("{id}/accept")]
    public async Task<IActionResult> AcceptSolicitation([FromRoute] string id, [FromBody] AcceptSolicitationCommand command)
    {
      var res = await _mediator.Send(command.SetId(id).ByProvider(_userLoggedAcessor.UserId));

      return await ResponseOkIfNotExistsNotificationsAsync(res);
    }

    [HttpPut("{id}/recuse")]
    public async Task<IActionResult> RecuseSolicitation([FromRoute] string id)
    {
      var res = await _mediator.Send(new RecuseSolicitationCommand().SetId(id).ByProvider(_userLoggedAcessor.UserId));

      return await ResponseOkIfNotExistsNotificationsAsync(res);
    }

    [HttpGet("opened")]
    public async Task<IActionResult> GetOpenedSolicitations()
    {
      var res = await _mediator.Send(new FindOpenedSolicitationsByProviderQuery(_userLoggedAcessor.UserId));

      return await ResponseOkIfNotExistsNotificationsAsync(res);
    }

  }
}
