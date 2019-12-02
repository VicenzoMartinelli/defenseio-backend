using DefenseIO.Infra.Shared.MediatR;
using System;

namespace DefenseIO.Services.Contracting.Commands.Solicitations.Create
{
  public class UpdateSearchRadiusCommand : Command
  {
    public Guid UserId { get; private set; }
    public long KiloMetersSearchRadius { get; set; }
    public UpdateSearchRadiusCommand ByUser(Guid userId)
    {
      UserId = userId;

      return this;
    }
  }
}
