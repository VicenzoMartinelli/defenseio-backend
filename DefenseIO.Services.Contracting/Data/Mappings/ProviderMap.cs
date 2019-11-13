using DefenseIO.Domain.Domains.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DefenseIO.Services.Contracting.Data.Mappings
{
  public class ProviderMap : IEntityTypeConfiguration<ProviderUser>
  {
    public void Configure(EntityTypeBuilder<ProviderUser> builder)
    {
      builder.ToTable("Provider");

      builder.OwnsOne(x => x.User, (build) =>
      {
        build
          .Property(x => x.Active)
          .IsRequired()
          .HasDefaultValue(true);

        build
          .Property(x => x.Name)
          .HasMaxLength(160);

        build
          .Property(x => x.Email);

        build
          .Property(x => x.PhoneNumber);

        build.Ignore(x => x.Client);

        build
          .OwnsOne(x => x.PrimaryLocation);
      });

      builder
        .HasKey(x => x.UserId);

      builder
        .Property(x => x.LicenseValidity)
        .IsRequired();

      builder
        .Property(x => x.BrazilianInscricaoEstadual)
        .HasMaxLength(15);
    }
  }
}
