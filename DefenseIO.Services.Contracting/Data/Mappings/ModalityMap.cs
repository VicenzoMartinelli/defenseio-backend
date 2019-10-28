using DefenseIO.Domain.Domains.Contracting.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;

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

      builder
        .HasData(new Modality[] {
          new Modality(){ Id = Guid.NewGuid(), Description = "Segurança pessoal", Key = ModalityType.Personal },
          new Modality(){ Id = Guid.NewGuid(), Description = "Escolta armada", Key = ModalityType.ArmedEscort },
          new Modality(){ Id = Guid.NewGuid(), Description = "Transporte de valores", Key = ModalityType.ValuesTransportation },
          new Modality(){ Id = Guid.NewGuid(), Description = "Segurança patrimonial", Key = ModalityType.AssetSurveillance },
        });
    }
  }
}
