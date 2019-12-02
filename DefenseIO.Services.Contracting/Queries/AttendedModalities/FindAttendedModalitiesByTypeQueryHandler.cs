using AutoMapper;
using DefenseIO.Domain.Domains.Contracting.Interfaces;
using DefenseIO.Domain.Domains.Contracting.ViewModels;
using DefenseIO.Domain.Domains.Geographic.Services;
using DefenseIO.Domain.Domains.Users.Interfaces;
using DefenseIO.Services.Contracting.Queries.AttendedModalities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DefenseIO.Services.Contracting.Queries.Modality
{
  public class FindAttendedModalitiesByTypeQueryHandler : IRequestHandler<FindAttendedModalitiesByTypeQuery, IEnumerable<AttendedModalityProviderViewModel>>
  {
    private readonly IAttendedModalityRepository _attendedModalityRepository;
    private readonly IContractingUserRepository _userRepository;
    private readonly ILoggedUserAcessor _userAccessor;
    private readonly IMapper _mapper;

    public FindAttendedModalitiesByTypeQueryHandler(
      IAttendedModalityRepository attendedModalityRepository,
      IContractingUserRepository userRepository,
      ILoggedUserAcessor userAccessor,
      IMapper mapper)
    {
      _attendedModalityRepository = attendedModalityRepository;
      _userRepository = userRepository;
      _userAccessor = userAccessor;
      _mapper = mapper;
    }

    public async Task<IEnumerable<AttendedModalityProviderViewModel>> Handle(FindAttendedModalitiesByTypeQuery request, CancellationToken cancellationToken)
    {
      var distService = new DistanceService();

      var locationData = await _userRepository.Query()
        .Where(x => x.Id == _userAccessor.UserId)
        .Select(x => new
        {
          x.KiloMetersSearchRadius,
          x.Longitude,
          x.Latitude
        })
        .FirstOrDefaultAsync();

      var query = await _attendedModalityRepository.Query()
        .Include(x => x.Modality)
        .Include(x => x.Provider)
        .Where(x => x.Modality.Key == request.Key)
        .Select(x => new AttendedModalityProviderViewModel
        {
          Id = x.Id,
          BasicValue = x.BasicValue,
          Method = x.Method,
          ProviderName = x.Provider.Name,
          ProviderRate = x.Provider.CurrentRating,
          MultiplyByEmployeesNumber = x.MultiplyByEmployeesNumber,
          ProviderUserId = x.Provider.Id,
          Latitude = x.Provider.Latitude,
          Longitude = x.Provider.Longitude
        }).ToListAsync();

      var userPoint = new GeoPoint(locationData.Latitude, locationData.Longitude);

      var result = query
        .Where(x =>
          distService.GetDistanceBetweenTwoPointsInKms(new GeoPoint(x.Latitude, x.Longitude), userPoint) <= locationData.KiloMetersSearchRadius)
        .Select(x =>
        {
          x.ProviderRate = Math.Round(x.ProviderRate, MidpointRounding.AwayFromZero);
          return x;
        });
      return result;
    }
  }
}
