using DefenseIO.Domain.Domains.Users;
using System;

namespace DefenseIO.Domain.Domains.Contracting.Entities
{
  public class ContractingUser
  {
    public Guid Id { get; set; }
    public UserType Type { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string DocumentIdentifier { get; set; }
    public double Longitude { get; set; }
    public double Latitude { get; set; }
    public string Cep { get; set; }
    public string Address { get; set; }
    public string AddressNumber { get; set; }
    public string Complement { get; set; }
    public string Burgh { get; set; }
    public Guid CityId { get; set; }
    public string BrazilianInscricaoEstadual { get; set; }
    public DateTime LicenseValidity { get; set; }
    public string Rg { get; set; }
    public DateTime BirthDate { get; set; }
    public double CurrentRating { get; set; }
    public long KiloMetersSearchRadius { get; set; }

  }
}
