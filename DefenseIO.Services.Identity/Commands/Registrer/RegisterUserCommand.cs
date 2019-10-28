using DefenseIO.Domain.Domains.Users;
using DefenseIO.Domain.Domains.Users.ViewModels;
using DefenseIO.Infra.Shared.MediatR;
using System;

namespace DefenseIO.Services.Identity.Commands.Registrer
{
  public class RegisterUserCommand : Command<TokenViewModel>
  {
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string PhoneNumber { get; set; }
    public UserType Type { get; private set; }
    public string DocumentIdentifier { get; set; }

    //Location
    public double Longitude { get; set; }
    public double Latitude { get; set; }
    public string Cep { get; set; }
    public string Address { get; set; }
    public string AddressNumber { get; set; }
    public string Complement { get; set; }
    public string Burgh { get; set; }
    public Guid CityId { get; set; }

    // Client
    public string Rg { get; set; }
    public DateTime BirthDate { get; set; }
    public long KiloMetersSearchRadius { get; set; }

    // Provider
    public string BrazilianInscricaoEstadual { get; set; }
    public DateTime LicenseValidity { get; set; }

    public RegisterUserCommand SetType(UserType type)
    {
      Type = type;

      return this;
    }
  }
}
