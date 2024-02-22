using Application.Repositories;
using Domain.Exceptions;
using MediatR;

namespace Application.Features.Blogs.Commands
{
    public class LikeBlogPostCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public class LikeBlogPostCommandHandler(
            IBlogPostRepository blogPostRepository) : IRequestHandler<LikeBlogPostCommand, Unit>
        {
            public async Task<Unit> Handle(LikeBlogPostCommand request, CancellationToken cancellationToken)
            {
                var blog = await blogPostRepository.GetFirst(bp => bp.Id == request.Id, true);
                if (blog is null)
                    throw new NotFoundByIdException<int>(request.Id);
                blog.LikeCount++;
                await blogPostRepository.SaveChangesAsync();
                return Unit.Value;
            }
        }
    }
}
