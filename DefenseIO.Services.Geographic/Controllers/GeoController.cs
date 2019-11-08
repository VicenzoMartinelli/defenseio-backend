using DefenseIO.Domain.Domains.Geographic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace DefenseIO.Services.Geographic.Controllers
{
  [Route("geo")]
  [ApiController]
  public class GeoController : ControllerBase
  {
    private readonly IDistrictRepository _districtRepository;
    private readonly ICityRepository _cityRepository;
    public GeoController(IDistrictRepository districtRepository, ICityRepository cityRepository)
    {
      _districtRepository = districtRepository;
      _cityRepository = cityRepository;
    }

    [HttpGet("districts")]
    public IActionResult FindDistricts()
    {
      return Ok(_districtRepository.Query().ToList());
    }

    [HttpGet("cities/name/{name}")]
    public IActionResult FindDistricts(string name)
    {
      return Ok(_cityRepository.Query(x => x.Name == name).FirstOrDefault());
    }

    [HttpGet("districts/{id:guid}/cities")]
    public IActionResult FindCities(Guid id)
    {
      return Ok(_cityRepository.Query(x => x.DistrictId == id).ToList());
    }
  }
}
