using AutoMapper;
using DefenseIO.Domain.Domains.Contracting.Interfaces;
using DefenseIO.Domain.Domains.Contracting.ViewModels;
using DefenseIO.Services.Contracting.Queries.AttendedModalities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DefenseIO.Services.Contracting.Queries.Modality
{
  public class FindAttendedModalitiesByTypeQueryHandler : IRequestHandler<FindAttendedModalitiesByTypeQuery, IEnumerable<AttendedModalityProviderViewModel>>
  {
    private readonly IAttendedModalityRepository _attendedModalityRepository;
    private readonly IMapper _mapper;

    public FindAttendedModalitiesByTypeQueryHandler(
      IAttendedModalityRepository attendedModalityRepository,
      IMapper mapper)
    {
      _attendedModalityRepository = attendedModalityRepository;
      _mapper = mapper;
    }

    public Task<IEnumerable<AttendedModalityProviderViewModel>> Handle(FindAttendedModalitiesByTypeQuery request, CancellationToken cancellationToken)
    {
      var res = _attendedModalityRepository.Query()
        .Include(x => x.Modality)
        .Include(x => x.Provider)
        .Where(x => x.Modality.Key == request.Key)
        .Select(x => new AttendedModalityProviderViewModel
        {
          Id = x.Id,
          BasicValue = x.BasicValue,
          Method = x.Method,
          ProviderName = x.Provider.User.Name,
          ProviderRate = 4,
          MultiplyByEmployeesNumber = x.MultiplyByEmployeesNumber,
          ProviderUserId = x.Provider.UserId
        }).AsEnumerable();

      return Task.FromResult(res);
    }
  }
}
