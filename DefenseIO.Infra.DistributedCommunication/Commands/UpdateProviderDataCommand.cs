using System;

namespace DefenseIO.Infra.DistributedCommunication.Commands
{
  public class UpdateProviderDataCommand
  {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
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
  }
}
