using Application.Features.Auth.Rules;
using Application.Features.Blogs.Dtos;
using Application.Repositories;
using Application.Utils.Aspects.Customs;
using Application.Utils.Helpers;
using Domain.Entities;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.BlogPosts.Commands
{
    public class UpdateBlogPostCommand : IRequest<ReturnedBlogPostDto>
    {
        public UpdateBlogPostDto UpdateBlogPostDto { get; set; }

        [SecuredOperation("admin,editor")]
        public class UpdateBlogPostCommandHandler( IBlogPostRepository blogPostRepository, FileHelper fileHelper) : IRequestHandler<UpdateBlogPostCommand, ReturnedBlogPostDto>
        {
            public async Task<ReturnedBlogPostDto> Handle(UpdateBlogPostCommand request, CancellationToken cancellationToken)
            {
                var path = String.Empty;
                if(request.UpdateBlogPostDto.File is not null)
                    path = fileHelper.UploadFile(request.UpdateBlogPostDto.File);

                var blog = await blogPostRepository.GetFirst(bp => bp.Id==request.UpdateBlogPostDto.Id,true);
                blog.Subject=request.UpdateBlogPostDto.Subject;
                blog.Content=request.UpdateBlogPostDto.Content;
                blog.UpdatedAt=DateTime.Now;
                if (!String.IsNullOrEmpty(path))
                    blog.ThumbnailImagePath=path;

                await blogPostRepository.SaveChangesAsync();
                var blogToReturn = new ReturnedBlogPostDto(blog.Id, blog.Subject, blog.Content);

                return blogToReturn;
            }
        }
    }
}
