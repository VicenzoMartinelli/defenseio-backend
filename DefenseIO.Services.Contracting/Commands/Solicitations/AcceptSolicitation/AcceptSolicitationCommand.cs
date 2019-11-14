using DefenseIO.Infra.Shared.Extensions;
using DefenseIO.Infra.Shared.MediatR;
using System;

namespace DefenseIO.Services.Contracting.Commands.Solicitations.Create
{
  public class AcceptSolicitationCommand : Command
  {
    // BASIC DATA
    public Guid Id { get; private set; }
    public int NumberOfEmployees { get; set; }
    public Guid ProviderId { get; private set; }

    public AcceptSolicitationCommand ByProvider(Guid providerId)
    {
      ProviderId = providerId;

      return this;
    }

    public AcceptSolicitationCommand SetId(string id)
    {
      Id = id.SafeParse();

      return this;
    }
  }
}
