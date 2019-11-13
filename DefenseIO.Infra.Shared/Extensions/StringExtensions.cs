using System;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace DefenseIO.Infra.Shared.Extensions
{
  public static class StringExtensions
  {
    public static string GetOnlyNumerics(this string val)
    {
      return Regex.Replace(val, "[^0-9]+", "");
    }

    public static string FormatValues(this string val, params object[] args)
    {
      return string.Format(val, args);
    }

    public static bool IsPresent(this string val)
    {
      return !string.IsNullOrEmpty(val);
    }

    public static string RemoveDiacritics(this string val)
    {
      if (null == val)
      {
        return null;
      }

      var chars = val
          .Normalize(NormalizationForm.FormD)
          .ToCharArray()
          .Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
          .ToArray();

      return new string(chars).Normalize(NormalizationForm.FormC);
    }

    public static Guid SafeParse(this string input)
    {
      try
      {
        return Guid.Parse(input);
      }
      catch (Exception)
      {
        return Guid.Empty;
      }
    }

  }
}
