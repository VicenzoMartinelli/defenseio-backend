using DefenseIO.Domain.Domains.Contracting.Entities.Solicitation;
using DefenseIO.Domain.Domains.Contracting.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DefenseIO.Services.Contracting.Queries.Solicitations
{
  public class FindOpenedSolicitationsByProviderQueryHandler : IRequestHandler<FindOpenedSolicitationsByProviderQuery, IEnumerable<Solicitation>>
  {
    private readonly ISolicitationRepository _solicitationRepository;

    public FindOpenedSolicitationsByProviderQueryHandler(ISolicitationRepository solicitationRepository)
    {
      _solicitationRepository = solicitationRepository;
    }

    public async Task<IEnumerable<Solicitation>> Handle(FindOpenedSolicitationsByProviderQuery request, CancellationToken cancellationToken)
    {
      var solicitations = await _solicitationRepository.Query()
        .Include(x => x.Client)
        .Where(x => x.ProviderId == request.ProviderId)
        .Where(x => x.Status == SolicitationStatus.Created)
        .ToListAsync();

      return solicitations;
    }
  }
}
