using DefenseIO.Domain.Domains.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DefenseIO.Services.Identity.Data.Mappings
{
  public class ClientUserMap : IEntityTypeConfiguration<ClientUser>
  {
    public void Configure(EntityTypeBuilder<ClientUser> builder)
    {
      builder.ToTable(nameof(ClientUser));

      builder
        .HasKey(x => x.UserId);

      builder
        .HasOne(x => x.User)
        .WithOne(x => x.Client);

      builder
        .Property(x => x.BirthDate)
        .IsRequired();

      builder
        .Property(x => x.Rg)
        .HasMaxLength(10);

      builder
        .Property(x => x.KiloMetersSearchRadius)
        .HasDefaultValue(10);

    }
  }
}
