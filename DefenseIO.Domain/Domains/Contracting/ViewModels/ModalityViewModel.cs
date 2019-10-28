using DefenseIO.Domain.Domains.Contracting.Entities;
using System;

namespace DefenseIO.Domain.Domains.Contracting.ViewModels
{
  public class ModalityViewModel
  {
    public Guid Id { get; set; }
    public ModalityType Key { get; set; }
    public string Description { get; set; }
  }
}
