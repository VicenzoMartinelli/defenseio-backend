using System;

namespace DefenseIO.Infra.Shared.Extensions
{
  public static class ConverterExtensions
  {
    public static string AsBase64Image(this byte[] value) => value != null ? "data:image/jpeg;base64," + Convert.ToBase64String(value) : null;
  }
}
