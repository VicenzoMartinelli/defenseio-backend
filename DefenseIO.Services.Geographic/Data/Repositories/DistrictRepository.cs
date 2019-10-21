using DefenseIO.Domain.Domains.Geographic;
using DefenseIO.Domain.Domains.Geographic.Interfaces;
using DefenseIO.Infra.Shared.Interfaces;
using DefenseIO.Services.Geographic.Data.Contexts;

namespace DefenseIO.Services.Geographic.Data.Repositories
{
  public class DistrictRepository : AbstractRepository<GeographicContext, District>, IDistrictRepository
  {
    public DistrictRepository(GeographicContext context) : base(context)
    {

    }
  }
}
