using DefenseIO.Domain.Domains.Geographic;
using DefenseIO.Domain.Domains.Geographic.Interfaces;
using DefenseIO.Infra.Shared.Interfaces;
using DefenseIO.Services.Geographic.Data.Contexts;

namespace DefenseIO.Services.Geographic.Data.Repositories
{
  public class CityRepository : AbstractRepository<GeographicContext, City>, ICityRepository
  {
    public CityRepository(GeographicContext context) : base(context)
    {

    }
  }
}
