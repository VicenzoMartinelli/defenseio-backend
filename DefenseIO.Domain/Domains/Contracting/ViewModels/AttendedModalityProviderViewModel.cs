using DefenseIO.Domain.Domains.Contracting.Entities;
using System;

namespace DefenseIO.Domain.Domains.Contracting.ViewModels
{
  public class AttendedModalityProviderViewModel
  {
    public Guid Id { get; set; }
    public BilingMethod Method { get; set; }
    public double BasicValue { get; set; }
    public bool MultiplyByEmployeesNumber { get; set; }
    public Guid ProviderUserId { get; set; }
    public string ProviderName { get; set; }
    public double ProviderRate { get; set; }
    public double Distance { get; set; }
    public double Longitude { get; set; }
    public double Latitude { get; set; }
  }
}
