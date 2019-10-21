using DefenseIO.Domain.Domains.Geographic;
using DefenseIO.Services.Geographic.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace DefenseIO.Services.Geographic.Data.Contexts
{
  public class GeographicContext : DbContext
  {
    public DbSet<City> Cities;
    public DbSet<District> Districts;

    public GeographicContext(DbContextOptions<GeographicContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.ApplyConfiguration(new CityMap());
      modelBuilder.ApplyConfiguration(new DistrictMap());
    }
  }
}
