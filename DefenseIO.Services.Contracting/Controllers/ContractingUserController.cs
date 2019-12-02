using DefenseIO.Domain.Domains.Users.Interfaces;
using DefenseIO.Infra.ApiConfig.Abstracts;
using DefenseIO.Infra.Shared.Notifications;
using DefenseIO.Services.Contracting.Commands.Solicitations.Create;
using DefenseIO.Services.Contracting.Queries.ContractingUser;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DefenseIO.Services.Contracting.Controllers
{
  [Route("contracting-user")]
  [ApiController]
  [Authorize]
  public class ContractingUserController : BaseApiController
  {
    private readonly ILoggedUserAcessor _userLoggedAccessor;

    public ContractingUserController(IMediator mediator, ILoggedUserAcessor userLoggedAcessor, NotificationContext notificationContext) : base(mediator, notificationContext)
    {
      _userLoggedAccessor = userLoggedAcessor;
    }

    [HttpGet("search-radius")]
    public async Task<IActionResult> GetSearchRadius()
    {
      var res = await _mediator.Send(new FindSearchRadiusByContractingUserQuery(_userLoggedAccessor.UserId));

      return await ResponseOkIfNotExistsNotificationsAsync(new
      {
        KiloMetersSearchRadius = res
      });
    }

    [HttpPut("search-radius")]
    public async Task<IActionResult> UpdateSearchRadius([FromBody] UpdateSearchRadiusCommand command)
    {
      var res = await _mediator.Send(command.ByUser(_userLoggedAccessor.UserId));

      return await ResponseOkIfNotExistsNotificationsAsync(res);
    }

    [HttpGet("provider-comments/{providerId:guid}")]
    public async Task<IActionResult> GetProviderComments([FromRoute] Guid providerId)
    {
      var res = await _mediator.Send(new FindCommentsByProviderQuery(providerId));

      return await ResponseOkIfNotExistsNotificationsAsync(res);
    }
  }
}
