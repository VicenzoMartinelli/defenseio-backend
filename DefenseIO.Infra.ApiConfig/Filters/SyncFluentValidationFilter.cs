using DefenseIO.Infra.Shared.Messages;
using DefenseIO.Infra.Shared.Notifications;
using DefenseIO.Infra.Shared.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;

namespace DefenseIO.Infra.ApiConfig.Filters
{
  public class SyncFluentValidationFilter : IActionFilter
  {
    private readonly NotificationContext _context;

    public SyncFluentValidationFilter(NotificationContext context)
    {
      _context = context;
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
      if (_context.AnyNotification)
      {
        var responseObj = new ResultWithErrors(_context.GetNotifications());

        if (ExisteNotFound(responseObj))
        {
          context.Result = new NotFoundObjectResult(responseObj)
          {
            ContentTypes = { "application/problem+json" }
          };
        }
        else
        {
          context.Result = new BadRequestObjectResult(responseObj)
          {
            ContentTypes = { "application/problem+json" }
          };
        }
        return;
      }

      if (!context.ModelState.IsValid)
      {
        context.Result = new BadRequestObjectResult(new { errors = context.ModelState.Values.SelectMany(v => v.Errors.Select(x => new Notification(string.Empty, nameof(Messages.InternalError), string.Empty, x.ErrorMessage, 400))) })
        {
          ContentTypes = { "application/problem+json" }
        };
      }
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
      if (_context.AnyNotification)
      {
        var responseObj = new ResultWithErrors(_context.GetNotifications());

        if (ExisteNotFound(responseObj))
        {
          context.Result = new NotFoundObjectResult(responseObj)
          {
            ContentTypes = { "application/problem+json" }
          };
          context.Canceled = true;
        }
        else
        {
          context.Result = new BadRequestObjectResult(responseObj)
          {
            ContentTypes = { "application/problem+json" }
          };
          context.Canceled = true;
        }
        return;
      }

      if (!context.ModelState.IsValid)
      {
        context.Result = new BadRequestObjectResult(new ResultWithErrors(context.ModelState.Values.SelectMany(v => v.Errors.Select(x => new Notification(string.Empty, nameof(Messages.InternalError), string.Empty, x.ErrorMessage, 400)))))
        {
          ContentTypes = { "application/problem+json" }
        };
        context.Canceled = true;
      }
    }

    private bool ExisteNotFound(ResultWithErrors responseObj)
    {
      return responseObj.Erros.Any(e => e.Status == StatusCodes.Status404NotFound);
    }
  }
}
