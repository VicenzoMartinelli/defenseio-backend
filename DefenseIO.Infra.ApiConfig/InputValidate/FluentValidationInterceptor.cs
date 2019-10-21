using DefenseIO.Infra.Shared.Notifications;
using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace DefenseIO.Infra.ApiConfig.InputValidate
{
  public class FluentValidationInterceptor : IValidatorInterceptor
  {
    public readonly NotificationContext _context;

    public FluentValidationInterceptor(NotificationContext context)
    {
      _context = context;
    }

    public ValidationResult AfterMvcValidation(ControllerContext controllerContext, ValidationContext validationContext, ValidationResult result)
    {
      if (!result.IsValid)
      {
        _context.BadRequest(result);
      }
      return result;
    }

    public ValidationContext BeforeMvcValidation(ControllerContext controllerContext, ValidationContext validationContext)
    {
      return validationContext;
    }
  }
}
