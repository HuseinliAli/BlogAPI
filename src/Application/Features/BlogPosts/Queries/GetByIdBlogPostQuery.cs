using Application.Features.BlogPosts.Rules;
using Application.Features.Blogs.Dtos;
using Application.Repositories;
using Domain.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.BlogPosts.Queries
{
    public class GetByIdBlogPostQuery : IRequest<BlogPostForDetailDto>
    {
        public int Id { get; set; }

        public class GetByIdBlogPostQueryHandler(IBlogPostRepository blogPostRepository,BlogPostBusinessRules blogPostBusinessRules) : IRequestHandler<GetByIdBlogPostQuery, BlogPostForDetailDto>
        {
            public async Task<BlogPostForDetailDto> Handle(GetByIdBlogPostQuery request, CancellationToken cancellationToken)
            {
                await blogPostBusinessRules.CheckBlogExists(request.Id);
                await blogPostBusinessRules.InCreaseView(request.Id);
                var blogPost = await blogPostRepository.GetPostAsync(request.Id);
                return blogPost;
            }
        }
    }
}
