using Application.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Persistence.Contexts;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories;
public class GenericRepository<TEntity, TKey>(BlogAppDbContext context) : IGenericRepository<TEntity, TKey>
    where TEntity : BaseEntity<TKey>, new()
{
    protected readonly DbSet<TEntity> table = context.Set<TEntity>();
    public void Add(TEntity entity)
    =>  table.Add(entity);
    

    public void Delete(TEntity entity)
    =>  table.Remove(entity);

    public IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> expression, bool changeTracker)
    {
        throw new NotImplementedException();
    }

    public IQueryable<TEntity> FindByAsync(Expression<Func<TEntity, bool>> expression, bool changeTracker)
        => !changeTracker ? table.Where(expression).AsNoTracking() : table.Where(expression);
    

    public IQueryable<TEntity> GetAll(bool changeTracker)
        => !changeTracker ? table.AsNoTracking() : table;

    public async Task<TEntity> GetFirst(Expression<Func<TEntity, bool>> expression, bool changeTracker)
        => !changeTracker ?await table.AsNoTracking().Where(expression).FirstOrDefaultAsync() :await table.Where(expression).FirstOrDefaultAsync();

    public Task<int> SaveChangesAsync()
    => context.SaveChangesAsync();

    public void Update(TEntity entity)
        => table.Update(entity);
}