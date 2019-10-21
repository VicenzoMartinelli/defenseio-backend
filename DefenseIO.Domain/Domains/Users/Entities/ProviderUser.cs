using System;

namespace DefenseIO.Domain.Domains.Users
{
  public class ProviderUser
  {
    public Guid UserId { get; set; }
    public string BrazilianInscricaoEstadual { get; set; }
    public DateTime LicenseValidity { get; set; }
    public virtual User User { get; set; }
  }
}
