using System;
using System.Collections.Generic;

namespace DefenseIO.Domain.Core
{
  public class Notification
  {
    public string Field { get; }
    public string Code { get; }
    public string Value { get; }
    public string Description { get; }
    public int? Status { get; }

    public Notification(string campo, string codigo, string valor, string descricao, int status = 400)
    {
      Field = campo;
      Code = codigo;
      Value = valor;
      Description = descricao;
      Status = status;
    }

    public Notification(string descricao, int status = 400)
    {
      Description = descricao;
      Status = status;
    }

    public override bool Equals(object obj)
    {
      return obj is Notification notificacao &&
             Field == notificacao.Field &&
             Code == notificacao.Code &&
             Value == notificacao.Value &&
             Description == notificacao.Description &&
             EqualityComparer<int?>.Default.Equals(Status, notificacao.Status);
    }

    public override int GetHashCode()
    {
      return HashCode.Combine(Field, Code, Value, Description, Status);
    }
  }
}
