using System;

namespace DefenseIO.Infra.Shared.Extensions
{
  public static class DateTimeExtensions
  {
    public static DateTime ToBrasiliaLocalDate(this DateTime value)
    {
      var timeZone = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");
      return TimeZoneInfo.ConvertTime(value, timeZone);
    }

    public static DateTime ParseFromUnixTimestamp(long seconds)
    {
      return new DateTime(1970, 1, 1).AddSeconds(seconds);
    }
  }
}
