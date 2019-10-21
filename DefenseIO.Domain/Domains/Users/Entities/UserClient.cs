using System;

namespace DefenseIO.Domain.Domains.Users
{
  public class ClientUser
  {
    public Guid UserId { get; set; }
    public string Rg { get; set; }
    public DateTime BirthDate { get; set; }
    public long KiloMetersSearchRadius { get; set; }

    public virtual User User { get; set; }
  }
}
