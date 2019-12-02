using DefenseIO.Domain.Domains.Contracting.Entities.Solicitation;
using MediatR;
using System;
using System.Collections.Generic;

namespace DefenseIO.Services.Contracting.Queries.Solicitations
{
  public class FindOpenedSolicitationsByClientQuery : IRequest<IEnumerable<Solicitation>>
  {
    public Guid ProviderId { get; private set; }
    public SolicitationStatus Status { get; set; }

    public FindOpenedSolicitationsByClientQuery(Guid providerId, SolicitationStatus status)
    {
      ProviderId = providerId;
      Status = status;
    }
  }
}
