using DefenseIO.Infra.Shared.Extensions;
using DefenseIO.Infra.Shared.Messages;
using FluentValidation;

namespace DefenseIO.Services.Contracting.Commands.AttendedModality
{
  public class CreateAttendedModalityValidator : AbstractValidator<CreateAttendedModalityCommand>
  {
    public CreateAttendedModalityValidator()
    {
      RuleFor(x => x.Method)
        .NotEmpty()
        .WithErrorCode(nameof(Messages.InvalidField))
        .WithMessage(x => Messages.InvalidField.FormatValues(nameof(x.Method)));

      RuleFor(x => x.ModalityId)
        .NotEmpty()
        .WithErrorCode(nameof(Messages.InvalidField))
        .WithMessage(x => Messages.InvalidField.FormatValues(nameof(x.ModalityId)));

      RuleFor(x => x.ProviderUserId)
        .NotEmpty()
        .WithErrorCode(nameof(Messages.InvalidField))
        .WithMessage(x => Messages.InvalidField.FormatValues(nameof(x.ProviderUserId)));

      RuleFor(x => x.BasicValue)
        .NotEmpty()
        .WithErrorCode(nameof(Messages.InvalidField))
        .WithMessage(x => Messages.InvalidField.FormatValues(nameof(x.BasicValue)));
    }
  }
}
