using DefenseIO.Domain.Domains.Contracting.Entities;
using System;

namespace DefenseIO.Domain.Domains.Contracting.ViewModels
{
  public class AttendedModalityViewModel
  {
    public Guid Id { get; set; }
    public BilingMethod Method { get; set; }
    public double BasicValue { get; set; }
    public bool MultiplyByEmployeesNumber { get; set; }
    public ModalityViewModel Modality { get; set; }
    public Guid ProviderUserId { get; set; }
  }
}
