using Application.RequestShapers;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories;
public interface IBlogPostRepository : IGenericRepository<BlogPost,int>
{
    Task<PagedList<BlogPost>> GetPostsAsync(bool changeTracker);
    Task<BlogPost> GetPostByIdAsync(int id);
    void SoftDelete(BlogPost post);
}
public interface IVoteBlogPostRepository : IGenericRepository<VoteBlogPost, int>
{

}
public interface IGenericRepository<TEntity,TKey>
    where TEntity:BaseEntity<TKey>,new()
{
    IQueryable<TEntity> GetAll(bool changeTracker);
    IQueryable<TEntity> FindBy(Expression<Func<TEntity,bool>> expression,bool changeTracker);
    void Add(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);
}

