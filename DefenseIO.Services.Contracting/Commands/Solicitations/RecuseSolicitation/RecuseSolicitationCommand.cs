using DefenseIO.Infra.Shared.Extensions;
using DefenseIO.Infra.Shared.MediatR;
using System;

namespace DefenseIO.Services.Contracting.Commands.Solicitations.Create
{
  public class RecuseSolicitationCommand : Command
  {
    // BASIC DATA
    public Guid Id { get; private set; }
    public Guid ProviderId { get; private set; }

    public RecuseSolicitationCommand ByProvider(Guid providerId)
    {
      ProviderId = providerId;

      return this;
    }

    public RecuseSolicitationCommand SetId(string id)
    {
      Id = id.SafeParse();

      return this;
    }
  }
}
