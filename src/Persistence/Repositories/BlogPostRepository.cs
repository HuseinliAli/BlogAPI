using Application.Repositories;
using Application.RequestShapers;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class BlogPostRepository : GenericRepository<BlogPost, int>,IBlogPostRepository
{
    public BlogPostRepository(BlogAppDbContext context):base(context)
    {
    
    }

    public async Task<PagedList<BlogPost>> GetPostsAsync(RequestParameters request)
    {
        return PagedList<BlogPost>.ToPagedList(await table.ToListAsync(),request.PageNumber,request.PageSize);
    }
}
