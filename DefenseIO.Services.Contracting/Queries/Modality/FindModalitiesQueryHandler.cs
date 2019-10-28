using AutoMapper;
using AutoMapper.QueryableExtensions;
using DefenseIO.Domain.Domains.Contracting.Interfaces;
using DefenseIO.Domain.Domains.Contracting.ViewModels;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DefenseIO.Services.Contracting.Queries.Modality
{
  public class FindModalitiesQueryHandler : IRequestHandler<FindModalitiesQuery, IEnumerable<ModalityViewModel>>
  {
    private readonly IModalityRepository _modalityRepository;
    private readonly IMapper _mapper;

    public FindModalitiesQueryHandler(
      IModalityRepository modalityRepository,
      IMapper mapper)
    {
      _modalityRepository = modalityRepository;
      _mapper = mapper;
    }

    public Task<IEnumerable<ModalityViewModel>> Handle(FindModalitiesQuery request, CancellationToken cancellationToken)
    {
      return Task.FromResult(_modalityRepository.Query()
        .ProjectTo<ModalityViewModel>(_mapper.ConfigurationProvider)
        .AsEnumerable());
    }
  }
}
