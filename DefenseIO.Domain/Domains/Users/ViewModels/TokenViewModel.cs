using System;

namespace DefenseIO.Domain.Domains.Users.ViewModels
{
  public class TokenViewModel
  {
    public string AccessToken { get; set; }
    public DateTime? Exp { get; set; }
    public DateTime? CreatedAt { get; set; }
  }
}
