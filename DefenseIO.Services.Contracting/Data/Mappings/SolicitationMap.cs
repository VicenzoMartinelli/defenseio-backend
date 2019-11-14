using DefenseIO.Domain.Domains.Contracting.Entities;
using DefenseIO.Domain.Domains.Contracting.Entities.Solicitation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DefenseIO.Services.Contracting.Data.Mappings
{
  public class SolicitationMap : IEntityTypeConfiguration<Solicitation>
  {
    public void Configure(EntityTypeBuilder<Solicitation> builder)
    {
      builder.ToTable(nameof(Solicitation));

      builder
        .HasKey(x => x.Id);

      builder
        .HasOne(x => x.Client)
        .WithMany()
        .HasForeignKey(x => x.ClientId);

      builder
        .HasOne(x => x.Provider)
        .WithMany()
        .HasForeignKey(x => x.ProviderId);

      builder.Property(t => t.Status)
        .HasConversion(new EnumToNumberConverter<SolicitationStatus, int>())
        .IsRequired();

      builder.Property(t => t.ModalityType)
        .HasConversion(new EnumToNumberConverter<ModalityType, int>())
        .IsRequired();

      builder
        .Property(x => x.SolicitationDate)
        .IsRequired();

      builder
        .Property(x => x.StartDateTime);

      builder
        .Property(x => x.EndDateTime);

      builder
        .Property(x => x.TurnOver);

      builder
        .Property(x => x.TurnStart);

      builder
        .Property(x => x.KiloMeters);

      builder
        .Property(x => x.NumberOfEmployeers);

      builder
        .Property(x => x.FinalCost);

      builder
        .OwnsOne(x => x.Location);

      builder
        .Property(x => x.Remark).HasMaxLength(1000);

      builder
        .HasOne(x => x.Evaluation)
        .WithOne(x => x.Solicitation);

      builder
        .HasOne(x => x.AttendedModality)
        .WithMany()
        .HasForeignKey(x => x.AttendedModalityId);
    }
  }
}
