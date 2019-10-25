using DefenseIO.Domain.Domains.Contracting.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DefenseIO.Services.Contracting.Data.Mappings
{
  public class AttendedModalityMap : IEntityTypeConfiguration<AttendedModality>
  {
    public void Configure(EntityTypeBuilder<AttendedModality> builder)
    {
      builder.ToTable(nameof(AttendedModality));

      builder
        .HasKey(x => x.Id);

      builder.Property(t => t.Method)
        .HasConversion(new EnumToStringConverter<BilingMethod>())
        .IsRequired();

      builder
        .Property(x => x.BasicValue)
        .IsRequired();

      builder
        .HasOne(x => x.Modality)
        .WithMany()
        .HasForeignKey(x => x.ModalityId);

      builder
        .Property(x => x.MultiplyByEmployeesNumber)
        .HasDefaultValue(false)
        .IsRequired();

      builder
        .Property(x => x.ProviderUserId)
        .IsRequired();

      builder.HasIndex(x => x.ProviderUserId);
      builder.HasIndex(x => x.ModalityId);
    }
  }
}
