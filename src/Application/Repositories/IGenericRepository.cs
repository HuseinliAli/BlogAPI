using Domain.Entities;
using System.Linq.Expressions;

namespace Application.Repositories;

public interface IGenericRepository<TEntity,TKey>
    where TEntity:BaseEntity<TKey>,new()
{
    IQueryable<TEntity> GetAll(bool changeTracker);
    IQueryable<TEntity> FindBy(Expression<Func<TEntity,bool>> expression,bool changeTracker);
    TEntity GetFirst(Expression<Func<TEntity, bool>> expression, bool changeTracker);
    void Add(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);
}

