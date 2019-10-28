using System;

namespace DefenseIO.Infra.Shared.Extensions
{
  public static class EnumExtensions
  {
    public static string AsNumericString(this Enum value)
    {
      return Convert.ToInt32(value).ToString();
    }

    public static T FromNumericString<T>(this string value) where T : Enum
    {
      return (T)Enum.ToObject(typeof(T), Convert.ToInt32(value));
    }
  }
}
