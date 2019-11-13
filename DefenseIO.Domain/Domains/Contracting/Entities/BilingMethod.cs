using System.ComponentModel;

namespace DefenseIO.Domain.Domains.Contracting.Entities
{
  public enum BilingMethod
  {
    [Description("Hora")]
    Hour,
    [Description("Periodo")]
    Period,
    [Description("Quilômetro")]
    KiloMeter,
    [Description("Fixo")]
    Fixed
  }
}
