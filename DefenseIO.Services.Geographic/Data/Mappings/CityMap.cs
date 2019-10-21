using DefenseIO.Domain.Domains.Geographic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DefenseIO.Services.Geographic.Data.Mappings
{
  public class CityMap : IEntityTypeConfiguration<City>
  {
    public void Configure(EntityTypeBuilder<City> builder)
    {
      builder.ToTable(nameof(City));

      builder
        .HasKey(x => x.Id);

      builder
        .Property(x => x.Name);

      builder
        .HasOne(x => x.District)
        .WithMany()
        .HasForeignKey(x => x.DistrictId);
    }
  }
}
