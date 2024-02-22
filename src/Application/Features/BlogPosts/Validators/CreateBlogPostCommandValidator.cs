using Application.Features.Blogs.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.BlogPosts.Validators
{
    public class CreateBlogPostCommandValidator : AbstractValidator<CreateBlogPostCommand>
    {
        public CreateBlogPostCommandValidator()
        {
            RuleFor(bp=>bp.CreateBlogPostDto.Content).NotEmpty().MinimumLength(100).MaximumLength(400);
            RuleFor(bp => bp.CreateBlogPostDto.Subject).NotEmpty().MinimumLength(3).MaximumLength(100);
            RuleFor(bp => bp.CreateBlogPostDto.CreatedBy).NotEmpty();
            RuleFor(bp => bp.CreateBlogPostDto.File).NotEmpty();
        }
    }
}
