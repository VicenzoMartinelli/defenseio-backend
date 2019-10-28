using DefenseIO.Domain.Domains.Users.ViewModels;
using DefenseIO.Infra.Shared.MediatR;

namespace DefenseIO.Services.Identity.Commands.Registrer
{
  public class LoginCommand : Command<TokenViewModel>
  {
    public string DocumentIdentifier { get; set; }
    public string Password { get; set; }
  }
}
