using FluentValidation;
using FluentValidation.Results;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DefenseIO.Infra.Shared.Entities
{
  public abstract class ValidatableEntity<T> : Entity where T : ValidatableEntity<T>
  {
    // Para validar
    [NotMapped]
    public ValidationResult ValidationResult { get; protected set; }

    protected ValidatableEntity()
    {
    }

    protected ValidatableEntity(DateTime data) : base(data)
    {
    }

    protected ValidatableEntity(Guid id, DateTime data) : base(id, data)
    {
    }

    public bool IsValid()
    {
      if (ValidationResult == null)
      {
        Validate();
      }

      return ValidationResult == null || ValidationResult.IsValid;
    }

    private void Validate()
    {
      ValidationResult = GetValidator().Validate((T)this);
    }

    protected abstract AbstractValidator<T> GetValidator();
  }
}
