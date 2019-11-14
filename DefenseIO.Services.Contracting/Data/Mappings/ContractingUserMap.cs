using DefenseIO.Domain.Domains.Contracting.Entities;
using DefenseIO.Domain.Domains.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DefenseIO.Services.Contracting.Data.Mappings
{
  public class ContractingUserMap : IEntityTypeConfiguration<ContractingUser>
  {
    public void Configure(EntityTypeBuilder<ContractingUser> build)
    {
      build.ToTable(nameof(ContractingUser));

      build
        .HasKey(x => x.Id);

      build.Property(t => t.Type)
        .HasConversion(new EnumToNumberConverter<UserType, int>())
        .IsRequired();

      build
        .Property(x => x.Name)
        .HasMaxLength(160);

      build
        .Property(x => x.Email);

      build
        .Property(x => x.PhoneNumber);

      build
        .Property(x => x.Rg);

      build
        .Property(x => x.BirthDate);

      build
        .Property(x => x.LicenseValidity)
        .IsRequired();

      build
        .Property(x => x.BrazilianInscricaoEstadual)
        .HasMaxLength(15);

      build
        .Property(x => x.Cep)
        .HasMaxLength(15)
        .IsRequired();

      build
        .Property(x => x.Address)
        .HasMaxLength(80)
        .IsRequired();

      build
        .Property(x => x.AddressNumber)
        .HasMaxLength(8);

      build
        .Property(x => x.Burgh)
        .HasMaxLength(80)
        .IsRequired();

      build
        .Property(x => x.CityId)
        .IsRequired();

      build
        .Property(x => x.Complement)
        .HasMaxLength(60);

      build
        .Property(x => x.Latitude)
        .IsRequired();

      build
        .Property(x => x.Longitude)
        .IsRequired();
    }
  }
}
