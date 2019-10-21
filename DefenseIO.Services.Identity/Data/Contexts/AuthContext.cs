using DefenseIO.Domain.Domains.Users;
using DefenseIO.Services.Identity.Data.Mappings;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace DefenseIO.Services.Identity.Data.Contexts
{
  public class AuthContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
  {
    public DbSet<ClientUser> Clients { get; set; }
    public DbSet<ProviderUser> Providers { get; set; }

    public AuthContext(DbContextOptions<AuthContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      base.OnModelCreating(builder);

      builder.Entity<IdentityUserRole<Guid>>().ToTable("UserRole");
      builder.Entity<IdentityUserLogin<Guid>>().ToTable("UserLogin");
      builder.Entity<IdentityUserClaim<Guid>>().ToTable("UserClaim");
      builder.Entity<IdentityRoleClaim<Guid>>().ToTable("RoleClaim");
      builder.Entity<IdentityUserClaim<Guid>>().ToTable("UserClaim");
      builder.Entity<IdentityUserToken<Guid>>().ToTable("UserToken");
      builder.Entity<IdentityRole<Guid>>().ToTable("Role");

      builder.ApplyConfiguration(new UserMap());
      builder.ApplyConfiguration(new LocationMap());
      builder.ApplyConfiguration(new ClientUserMap());
      builder.ApplyConfiguration(new ProviderUserMap());
    }
  }
}
