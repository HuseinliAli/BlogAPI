using Application.Features.Auth.Rules;
using Application.Features.BlogPosts.Rules;
using Application.Repositories;
using Application.Utils.Aspects.Customs;
using Domain.Exceptions;
using MediatR;

namespace Application.Features.Blogs.Commands
{
    public class DeleteBlogPostCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }

        [SecuredOperation("admin,editor")]
        public class DeleteBlogPostCommandHandler(
            IBlogPostRepository blogPostRepository,
            AuthBusinessRules authBusinessRules) : IRequestHandler<DeleteBlogPostCommand,Unit>
        {
            public async Task<Unit> Handle(DeleteBlogPostCommand request, CancellationToken cancellationToken)
            {
                await authBusinessRules.CheckUserExists(request.UserId);
                var blog = await blogPostRepository.GetFirst(bp => bp.Id == request.Id, false);
                if (blog is null)
                    throw new NotFoundByIdException<int>(request.Id);
                blog.DeletedBy = request.UserId;
                blogPostRepository.Delete(blog);
                await blogPostRepository.SaveChangesAsync();
                return Unit.Value;
            }
        }
    }
}
