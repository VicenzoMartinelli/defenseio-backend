using System;

namespace DefenseIO.Domain.Domains.Users
{
  public class Location
  {
    public double Longitude { get; set; }
    public double Latitude { get; set; }
    public string Cep { get; set; }
    public string Address { get; set; }
    public string AddressNumber { get; set; }
    public string Complement { get; set; }
    public string Burgh { get; set; }
    public Guid CityId { get; set; }
  }
}
