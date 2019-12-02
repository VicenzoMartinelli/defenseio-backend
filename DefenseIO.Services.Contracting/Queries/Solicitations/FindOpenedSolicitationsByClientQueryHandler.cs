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
  public class FindOpenedSolicitationsByClientQueryHandler : IRequestHandler<FindOpenedSolicitationsByClientQuery, IEnumerable<Solicitation>>
  {
    private readonly ISolicitationRepository _solicitationRepository;

    public FindOpenedSolicitationsByClientQueryHandler(ISolicitationRepository solicitationRepository)
    {
      _solicitationRepository = solicitationRepository;
    }

    public async Task<IEnumerable<Solicitation>> Handle(FindOpenedSolicitationsByClientQuery request, CancellationToken cancellationToken)
    {
      var solicitations = await _solicitationRepository.Query()
        .Include(x => x.Provider)
        .Where(x => x.ClientId == request.ProviderId)
        .Where(x => x.Status == request.Status)
        .ToListAsync();

      return solicitations;
    }
  }
}
