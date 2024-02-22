using Application.Repositories;
using Application.RequestShapers;
using Domain.Dtos;
using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class BlogPostRepository : GenericRepository<BlogPost, int>, IBlogPostRepository
{
    private readonly BlogAppDbContext _context;
    public BlogPostRepository(BlogAppDbContext context) : base(context)
    {
        _context=context;
    }

    public async Task<BlogPostForDetailDto> GetPostAsync(int id)
    {
        var result = from bp in _context.BlogPosts
                     where bp.Id == id
                     select new BlogPostForDetailDto(
                         bp.Id,
                         bp.ThumbnailImagePath,
                         bp.Subject,
                         bp.Content,
                         bp.ViewCount,
                         0,
                         0,
                         bp.CreatedAt
                     );

        return await result.AsNoTracking().FirstOrDefaultAsync();
    }

    public async Task<PagedList<BlogPostForListDto>> GetPostsAsync(RequestParameters request)
    {
        var dtos = from bp in _context.BlogPosts
                     join vb in _context.VoteBlogPosts
                     on bp.Id equals vb.BlogPostId into voteGroup
                     select new BlogPostForListDto(bp.Id,
                     bp.ThumbnailImagePath,
                     bp.Subject,
                     bp.ViewCount,
                     0,
                     0,
                     bp.CreatedAt);
        var result = await dtos.ToListAsync();
        return PagedList<BlogPostForListDto>.ToPagedList(result, request.PageNumber, request.PageSize);
    }
}
