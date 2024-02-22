using Application.Features.BlogPosts.Commands;
using FluentValidation;

namespace Application.Features.BlogPosts.Validators
{
    public class UpdateBlogPostCommandValidator : AbstractValidator<UpdateBlogPostCommand>
    {
        public UpdateBlogPostCommandValidator()
        {
            RuleFor(bp => bp.UpdateBlogPostDto.Id).NotEmpty();
            RuleFor(bp => bp.UpdateBlogPostDto.Content).NotEmpty().MinimumLength(100).MaximumLength(400);
            RuleFor(bp => bp.UpdateBlogPostDto.Subject).NotEmpty().MinimumLength(3).MaximumLength(100);
        }
    }
}
