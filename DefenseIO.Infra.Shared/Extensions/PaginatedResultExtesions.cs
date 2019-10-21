using AutoMapper;
using DefenseIO.Infra.Shared.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace DefenseIO.Infra.Shared.Extensions
{
  public static class PaginatedResultExtesions
  {
    public static PaginatedResultViewModel<TViewModel> ToPaginatedResult<TViewModel>(this IQueryable<TViewModel> query, int pageNumber = 1, int pageSize = 25)
    {
      var skip = (pageNumber - 1) * pageSize;

      var total = query.Count();


      var list = query.Skip(skip)
          .Take(pageSize)
          .ToList();

      return new PaginatedResultViewModel<TViewModel>(list, pageNumber, pageSize, total);
    }
    public static PaginatedResultViewModel<TViewModel> ToResultadoPaginado<TEntity, TViewModel>(this IMapper mapper, IQueryable<TEntity> query, int pageNumber = 1, int pageSize = 25) where TEntity : Entity
    {
      var skip = (pageNumber - 1) * pageSize;

      var total = query.Count();

      var list = query.Skip(skip)
          .Take(pageSize)
          .ToList();

      return new PaginatedResultViewModel<TViewModel>(
        mapper.Map<ICollection<TEntity>, ICollection<TViewModel>>(list), pageNumber, pageSize, total);
    }
    public static PaginatedResultViewModel<TViewModel> ToPaginatedResult<TViewModel>(this IEnumerable<TViewModel> query, int pageNumber = 1, int pageSize = 25)
    {
      return query.AsQueryable().ToPaginatedResult(pageNumber, pageSize);
    }
    public static PaginatedResultViewModel<TViewModel> ToPaginatedResult<TEntity, TViewModel>(this IEnumerable<TEntity> query, int pageNumber = 1, int pageSize = 25) where TEntity : Entity
    {
      return query.AsQueryable().ToPaginatedResult<TEntity, TViewModel>(pageNumber, pageSize);
    }
  }
}
