using Application.Repositories;
using Application.RequestShapers;
using Domain.Dtos;
using MediatR;

namespace Application.Features.BlogPosts.Queries
{
    public class GetListBlogPostQuery : IRequest<PagedList<BlogPostForListDto>>
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }

        public class GetListBlogPostQueryHandler(IBlogPostRepository blogPostRepository) : IRequestHandler<GetListBlogPostQuery, PagedList<BlogPostForListDto>>
        {
            public async Task<PagedList<BlogPostForListDto>> Handle(GetListBlogPostQuery request, CancellationToken cancellationToken)
            {
                var result = await blogPostRepository.GetPostsAsync(new RequestParameters() {PageNumber=request.PageNumber,PageSize=request.PageSize});
                return result;
            }
        }
    }
}
