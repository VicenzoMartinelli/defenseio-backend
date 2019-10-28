using DefenseIO.Infra.ApiConfig.Abstracts;
using DefenseIO.Infra.Shared.Notifications;
using DefenseIO.Services.Contracting.Queries.Modality;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DefenseIO.Services.Contracting.Controllers
{
  [Route("modalities")]
  [ApiController]
  public class ModalityController : BaseApiController
  {
    public ModalityController(IMediator mediator, NotificationContext notificationContext) : base(mediator, notificationContext)
    {

    }

    [HttpGet()]
    public async Task<IActionResult> FindAllModalities()
    {
      var res = await _mediator.Send(new FindModalitiesQuery());

      return await ResponseOkIfNotExistsNotificationsAsync(res);
    }
  }
}
