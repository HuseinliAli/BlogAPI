using Application.Features.Auth.Rules;
using Application.Features.Blogs.Dtos;
using Application.Repositories;
using Application.Utils.Aspects.Customs;
using Application.Utils.Helpers;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Blogs.Commands
{
    public class CreateBlogPostCommand : IRequest<ReturnedBlogPostDto>
    {
       public CreateBlogPostDto CreateBlogPostDto { get; set; }

        [SecuredOperation("admin,editor")]
        public class CreateBlogPostCommandHandler(IUserRepository userRepository, IBlogPostRepository blogPostRepository,FileHelper fileHelper,AuthBusinessRules authBusinessRules) : IRequestHandler<CreateBlogPostCommand, ReturnedBlogPostDto>
        {      
            public async Task<ReturnedBlogPostDto> Handle(CreateBlogPostCommand request, CancellationToken cancellationToken)
            {
                await authBusinessRules.CheckUserExists(request.CreateBlogPostDto.CreatedBy);
                var path = fileHelper.UploadFile(request.CreateBlogPostDto.File);
                var blog = new BlogPost()
                {
                    ThumbnailImagePath = path,
                    CreatedBy = request.CreateBlogPostDto.CreatedBy,
                    Subject = request.CreateBlogPostDto.Subject,
                    Content=request.CreateBlogPostDto.Content,
                };
          
                blogPostRepository.Add(blog);
                await blogPostRepository.SaveChangesAsync();

                var blogToReturn = new ReturnedBlogPostDto(blog.Id,blog.Subject,blog.Content);
                return blogToReturn;
            }
        }
    }


}
