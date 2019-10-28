using DefenseIO.Domain.Domains.Contracting.Entities;
using DefenseIO.Domain.Domains.Contracting.ViewModels;
using DefenseIO.Infra.Shared.MediatR;
using System;

namespace DefenseIO.Services.Contracting.Commands.AttendedModality
{
  public class CreateAttendedModalityCommand : Command<AttendedModalityViewModel>
  {
    public Guid Id { get; private set; }
    public BilingMethod Method { get; set; }
    public double BasicValue { get; set; }
    public bool MultiplyByEmployeesNumber { get; set; }
    public Guid ProviderUserId { get; private set; }
    public Guid ModalityId { get; set; }

    public CreateAttendedModalityCommand()
    {
      Id = Guid.NewGuid();
    }

    public CreateAttendedModalityCommand ByProviderUserId(Guid providerUserId)
    {
      ProviderUserId = providerUserId;
      return this;
    }
  }
}
