using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DefenseIO.Infra.Shared.Extensions
{
  public static class LinqExtensions
  {
    public static async Task<bool> AnyAsync<T>(
        this IEnumerable<T> source, Func<T, Task<bool>> func, bool invert = false)
    {
      foreach (var element in source)
      {
        var result = await func(element);

        if (invert)
          result = !result;

        if (result)
          return true;
      }
      return false;
    }

    public static async Task<bool> AllAsync<TSource>(
        this IEnumerable<TSource> source, Func<TSource,
            Task<bool>> predicate,
            bool invert = false)
    {
      foreach (var item in source)
      {
        var result = await predicate(item);

        if (invert)
          result = !result;

        if (!result)
          return false;
      }
      return true;
    }

    public static IEnumerable<TSource> If<TSource>(
        this IEnumerable<TSource> source,
        bool condition,
        Func<IEnumerable<TSource>, IEnumerable<TSource>> branch)
    {
      return condition ? source : branch(source);
    }
  }
}
