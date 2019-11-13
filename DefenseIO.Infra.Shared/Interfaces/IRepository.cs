using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DefenseIO.Infra.Shared.Interfaces
{
  public interface IRepository<TEntity> : IDisposable where TEntity : class
  {
    Task Add(TEntity obj);
    Task Update(TEntity obj);
    Task Remove(Guid id);
    Task Remove(TEntity entity);
    Task<TEntity> FindById(Guid id);
    IQueryable<TEntity> Query();
    IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> predicado);
    Task<bool> Exists(Expression<Func<TEntity, bool>> predicado);

    Task<bool> SaveChanges();
  }
}
