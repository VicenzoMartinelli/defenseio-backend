using DefenseIO.Domain.Domains.Contracting.Interfaces;
using DefenseIO.Domain.Domains.Contracting.ViewModels;
using DefenseIO.Services.Contracting.Queries.ContractingUser;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DefenseIO.Services.Contracting.Queries.Modality
{
  public class FindCommentsByProviderQueryHandler : IRequestHandler<FindCommentsByProviderQuery, IEnumerable<ProviderCommentsViewModel>>
  {
    private readonly ISolicitationEvaluationRepository _evaluationRepository;

    public FindCommentsByProviderQueryHandler(
      ISolicitationEvaluationRepository evaluationRepository)
    {
      _evaluationRepository = evaluationRepository;
    }

    public async Task<IEnumerable<ProviderCommentsViewModel>> Handle(FindCommentsByProviderQuery request, CancellationToken cancellationToken)
    {
      var comments = await _evaluationRepository.Query()
        .Where(x => x.ProviderId == request.ProviderId)
        .Select(x => new ProviderCommentsViewModel()
        {
          Comment = x.Comment,
          EvaluationDate = x.EvaluationDate
        })
        .OrderByDescending(x => x.EvaluationDate)
        .ToListAsync();

      return comments;
    }
  }
}
