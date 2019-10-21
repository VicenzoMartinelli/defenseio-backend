using DefenseIO.Domain.Domains.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DefenseIO.Services.Identity.Data.Mappings
{
  public class UserMap : IEntityTypeConfiguration<User>
  {
    public void Configure(EntityTypeBuilder<User> builder)
    {
      builder.ToTable(nameof(User));

      builder
      .Property(x => x.Active)
      .IsRequired()
      .HasDefaultValue(true);

      builder
        .Property(x => x.LastPasswordReset);

      builder.Property(t => t.Type)
        .HasConversion(new EnumToNumberConverter<UserType, int>())
        .IsRequired();

      builder
        .Property(x => x.Name)
        .HasMaxLength(160);

      builder
        .OwnsOne(x => x.PrimaryLocation);
    }
  }
}
