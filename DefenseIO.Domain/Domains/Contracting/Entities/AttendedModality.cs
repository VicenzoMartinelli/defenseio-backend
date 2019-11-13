using DefenseIO.Domain.Domains.Users;
using System;

namespace DefenseIO.Domain.Domains.Contracting.Entities
{
  public class AttendedModality
  {
    public Guid Id { get; set; }
    public BilingMethod Method { get; set; }
    public double BasicValue { get; set; }
    public bool MultiplyByEmployeesNumber { get; set; }
    public Guid ProviderUserId { get; set; }
    public Guid ModalityId { get; set; }

    public virtual ProviderUser Provider { get; set; }
    public virtual Modality Modality { get; set; }
  }
}
