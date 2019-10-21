using DefenseIO.Domain.Domains.Geographic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DefenseIO.Services.Geographic.Data.Mappings
{
  public class DistrictMap : IEntityTypeConfiguration<District>
  {
    public void Configure(EntityTypeBuilder<District> builder)
    {
      builder.ToTable(nameof(District));

      builder.HasKey(x => x.Id);

      builder.Property(x => x.Name).IsRequired();

      builder.Property(x => x.Initials).HasMaxLength(3).IsRequired();
    }
  }
}
