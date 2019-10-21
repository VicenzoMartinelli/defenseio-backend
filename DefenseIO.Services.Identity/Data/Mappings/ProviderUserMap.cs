using DefenseIO.Domain.Domains.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DefenseIO.Services.Identity.Data.Mappings
{
  public class ProviderUserMap : IEntityTypeConfiguration<ProviderUser>
  {
    public void Configure(EntityTypeBuilder<ProviderUser> builder)
    {
      builder.ToTable(nameof(ProviderUser));

      builder
        .HasKey(x => x.UserId);

      builder
        .HasOne(x => x.User)
        .WithOne(x => x.Provider);

      builder
        .Property(x => x.LicenseValidity)
        .IsRequired();

      builder
        .Property(x => x.BrazilianInscricaoEstadual)
        .HasMaxLength(15);
    }
  }
}
