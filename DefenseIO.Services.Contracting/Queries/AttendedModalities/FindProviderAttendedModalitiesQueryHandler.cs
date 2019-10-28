using AutoMapper;
using AutoMapper.QueryableExtensions;
using DefenseIO.Domain.Domains.Contracting.Interfaces;
using DefenseIO.Domain.Domains.Contracting.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DefenseIO.Services.Contracting.Queries.Modality
{
  public class FindProviderAttendedModalitiesQueryHandler : IRequestHandler<FindProviderAttendedModalitiesQuery, IEnumerable<AttendedModalityViewModel>>
  {
    private readonly IAttendedModalityRepository _attendedModalityRepository;
    private readonly IMapper _mapper;

    public FindProviderAttendedModalitiesQueryHandler(
      IAttendedModalityRepository attendedModalityRepository,
      IMapper mapper)
    {
      _attendedModalityRepository = attendedModalityRepository;
      _mapper = mapper;
    }

    public Task<IEnumerable<AttendedModalityViewModel>> Handle(FindProviderAttendedModalitiesQuery request, CancellationToken cancellationToken)
    {
      var res = _attendedModalityRepository
        .Query(x => x.ProviderUserId == request.ProviderId)
        .Include(x => x.Modality)
        .ProjectTo<AttendedModalityViewModel>(_mapper.ConfigurationProvider)
        .AsEnumerable();

      return Task.FromResult(res);
    }
  }
}
