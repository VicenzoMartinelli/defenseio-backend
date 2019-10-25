using System;

namespace DefenseIO.Domain.Domains.Contracting.Entities
{
  public class Modality
  {
    public Guid Id { get; set; }
    public ModalityType Key { get; set; }
    public string Description { get; set; }
  }
}
