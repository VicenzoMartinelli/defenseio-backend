using DefenseIO.Domain.Domains.Contracting.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DefenseIO.Services.Identity.Data.Mappings
{
  public class ModalityMap : IEntityTypeConfiguration<Modality>
  {
    public void Configure(EntityTypeBuilder<Modality> builder)
    {
      builder.ToTable(nameof(Modality));

      builder
        .HasKey(x => x.Id);

      builder.Property(t => t.Key)
        .HasConversion(new EnumToStringConverter<ModalityType>())
        .IsRequired();

      builder
        .Property(x => x.Description)
        .HasMaxLength(80);
    }
  }
}
