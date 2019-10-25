using DefenseIO.Domain.Domains.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DefenseIO.Services.Contracting.Data.Mappings
{
  public class LocationMap : IEntityTypeConfiguration<Location>
  {
    public void Configure(EntityTypeBuilder<Location> builder)
    {
      builder
        .Property(x => x.Cep)
        .HasMaxLength(15)
        .IsRequired();

      builder
        .Property(x => x.Address)
        .HasMaxLength(80)
        .IsRequired();

      builder
        .Property(x => x.AddressNumber)
        .HasMaxLength(8);

      builder
        .Property(x => x.Burgh)
        .HasMaxLength(80)
        .IsRequired();

      builder
        .Property(x => x.CityId)
        .IsRequired();

      builder
        .Property(x => x.Complement)
        .HasMaxLength(60);

      builder
        .Property(x => x.Latitude)
        .IsRequired();

      builder
        .Property(x => x.Longitude)
        .IsRequired();
    }
  }
}
