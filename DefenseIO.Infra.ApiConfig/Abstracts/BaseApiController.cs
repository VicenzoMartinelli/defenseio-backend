using DefenseIO.Infra.Shared.Notifications;
using DefenseIO.Infra.Shared.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace DefenseIO.Infra.ApiConfig.Abstracts
{
  public abstract class BaseApiController : ControllerBase
  {
    protected readonly NotificationContext _notificationContext;
    protected readonly IMediator _mediator;

    protected BaseApiController(IMediator mediator, NotificationContext notificationContext)
    {
      _mediator = mediator;
      _notificationContext = notificationContext;
    }

    protected async Task<IActionResult> ResponseCreatedAsync(string action, object routeValues, object value = null)
    {
      return await Task.FromResult(CreatedAtAction(action, routeValues, value));
    }

    protected async Task<IActionResult> ResponseOkAsync(object resultado = null)
    {
      return await Task.FromResult(resultado == null ? (IActionResult)Ok() : Ok(resultado));
    }

    protected Task<IActionResult> ResponseOkIfNotExistsNotificationsAsync(object resultado = null)
    {
      return _notificationContext.AnyNotification ? ResponseNotifications() : ResponseOkAsync(resultado);
    }

    protected Task<IActionResult> ResponseOkOrBadRequestByCommandResult<T>(CommandResult<T> commandResult)
    {
      return commandResult.IsSuccess ? ResponseOkAsync(commandResult.Body) : ResponseNotifications();
    }

    protected Task<IActionResult> ResponseOkOrBadRequestByCommandResult(bool commandResult)
    {
      return commandResult ? ResponseOkAsync() : ResponseNotifications();
    }

    protected async Task<IActionResult> ResponseUnauthorizedAsync(object resultado = null)
    {
      return await Task.FromResult(Unauthorized(resultado));
    }

    protected async Task<IActionResult> ResponseNotFoundAsync(string codigo = null, string mensagem = null)
    {
      if (!string.IsNullOrEmpty(mensagem))
      {
        _notificationContext.NotFound(codigo, mensagem);
      }
      return await Task.FromResult(NotFound());
    }

    protected async Task<IActionResult> ResponseBadRequestAsync(string codigo, string message)
    {
      if (!string.IsNullOrEmpty(message))
      {
        _notificationContext.BadRequest(codigo, message);
      }
      return await Task.FromResult(BadRequest());
    }

    protected async Task<IActionResult> ResponseBadRequestAsync(string message = null)
    {
      if (message != null)
      {
        _notificationContext.BadRequest(string.Empty, message);
      }
      return await Task.FromResult(BadRequest());
    }

    protected async Task<IActionResult> ResponseNoContentAsync()
    {
      return await Task.FromResult(NoContent());
    }

    protected async Task<IActionResult> ResponseNotifications()
    {
      return await Task.FromResult(BadRequest());
    }

    protected async Task<IActionResult> ResultadoPaginadoAsync<T>(PaginatedResultViewModel<T> resultadoPaginado)
    {
      return await Task.FromResult(Ok(resultadoPaginado));
    }

    protected bool OperacaoValida()
    {
      return !_notificationContext.AnyNotification && (_notificationContext.Notifications.Any());
    }
  }
}
