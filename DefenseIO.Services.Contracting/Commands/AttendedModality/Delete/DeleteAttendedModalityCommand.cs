using DefenseIO.Infra.Shared.MediatR;
using System;

namespace DefenseIO.Services.Contracting.Commands.AttendedModality
{
  public class DeleteAttendedModalityCommand : Command
  {
    public Guid Id { get; private set; }

    public DeleteAttendedModalityCommand(Guid id)
    {
      Id = id;
    }
  }
}
