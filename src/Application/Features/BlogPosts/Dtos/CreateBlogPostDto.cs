using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Blogs.Dtos
{
    public record CreateBlogPostDto(IFormFile File, string Subject,string Content,Guid CreatedBy);
    public record ReturnedBlogPostDto(int Id,string Subject, string Content);
    public record UpdateBlogPostDto(int Id,IFormFile? File,string Subject,string Content);
    public record GetByIdBlogPostDto(Guid Id);
}
