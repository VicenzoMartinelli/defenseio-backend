using System;

namespace DefenseIO.Domain.Domains.Geographic
{
  public class City
  {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid DistrictId { get; set; }

    public virtual District District { get; set; }
  }
}
