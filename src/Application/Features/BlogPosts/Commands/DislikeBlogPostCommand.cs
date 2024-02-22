using Application.Repositories;
using Application.Utils.Aspects.Customs;
using Domain.Exceptions;
using MediatR;

namespace Application.Features.Blogs.Commands
{
    public class DislikeBlogPostCommand : IRequest<Unit>
    {
        public int Id { get; set; }

        public class DislikeBlogPostCommandHandler(
            IBlogPostRepository blogPostRepository) : IRequestHandler<DislikeBlogPostCommand, Unit>
        {
            public async Task<Unit> Handle(DislikeBlogPostCommand request, CancellationToken cancellationToken)
            {
                var blog = await blogPostRepository.GetFirst(bp => bp.Id == request.Id, true);
                if (blog is null)
                    throw new NotFoundByIdException<int>(request.Id);
                blog.DisLikeCount++;
                await blogPostRepository.SaveChangesAsync();
                return Unit.Value;
            }
        }
    }
}
