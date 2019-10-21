using DefenseIO.Infra.Shared.Messages;
using DefenseIO.Infra.Shared.Notifications;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace DefenseIO.Infra.ApiConfig.Middleware
{
  public static class GlobalErrorHandlingMiddleware
  {
    public static void UseGlobalErrorHandler(this IApplicationBuilder app)
    {
      app.UseExceptionHandler(appError =>
      {
        appError.Run(async context =>
              {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Response.ContentType = "application/json";

                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                if (contextFeature != null)
                {
                  await context.Response.WriteAsync(JsonConvert.SerializeObject(new { errors = new Notification[] { new Notification(string.Empty, nameof(Messages.InternalError), string.Empty, contextFeature.Error.Message, 500) } }));
                }
              });
      });
    }
  }
}
