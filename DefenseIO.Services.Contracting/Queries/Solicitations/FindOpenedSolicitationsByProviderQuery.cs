using DefenseIO.Domain.Domains.Contracting.Entities.Solicitation;
using MediatR;
using System;
using System.Collections.Generic;

namespace DefenseIO.Services.Contracting.Queries.Solicitations
{
  public class FindOpenedSolicitationsByProviderQuery : IRequest<IEnumerable<Solicitation>>
  {
    public Guid ProviderId { get; private set; }

    public FindOpenedSolicitationsByProviderQuery(Guid providerId)
    {
      ProviderId = providerId;
    }
  }
}
