using Microsoft.AspNetCore.Identity;
using System;

namespace DefenseIO.Domain.Domains.Users
{
  public class User : IdentityUser<Guid>
  {
    public string Name { get; set; }
    public bool Active { get; set; }
    public Location PrimaryLocation { get; set; }
    public DateTime? LastPasswordReset { get; set; }
    public UserType Type { get; set; }
    public string DocumentIdentifier
    {
      get => UserName;
      set => UserName = value;
    }

    public virtual ClientUser Client { get; set; }
    public virtual ProviderUser Provider { get; set; }
  }
}
