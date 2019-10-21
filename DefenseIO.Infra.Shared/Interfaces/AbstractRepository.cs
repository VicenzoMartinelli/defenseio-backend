using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DefenseIO.Infra.Shared.Interfaces
{
  public abstract class AbstractRepository<TContext, TEntity> : IRepository<TEntity> where TEntity : class where TContext : DbContext
  {
    protected readonly TContext Db;
    protected readonly DbSet<TEntity> DbSet;

    protected AbstractRepository(TContext context)
    {
      Db = context;
      DbSet = Db.Set<TEntity>();
    }

    public async Task<int> SaveChanges()
    {
      return await Db.SaveChangesAsync();
    }
    public void Dispose()
    {
      Db.Dispose();
    }
    public async Task Add(TEntity obj)
    {
      await DbSet.AddAsync(obj);
    }

    public Task Update(TEntity obj)
    {
      Db.Entry(obj).State = EntityState.Modified;
      DbSet.Update(obj);

      return Task.CompletedTask;
    }

    public async Task Remove(Guid id)
    {
      var obj = await FindById(id);

      DbSet.Remove(obj);
    }

    public Task Remove(TEntity entity)
    {
      throw new NotImplementedException();
    }

    public async Task<TEntity> FindById(Guid id)
    {
      return await DbSet.FindAsync(id);
    }
    public IQueryable<TEntity> Query()
    {
      return DbSet.AsNoTracking();
    }

    public IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> predicado)
    {
      return DbSet.AsNoTracking().Where(predicado);
    }

    public async Task<bool> Exists(Expression<Func<TEntity, bool>> predicado)
    {
      return await DbSet.AsNoTracking().Where(predicado).AnyAsync();
    }
  }
}
