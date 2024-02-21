using Application.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class VoteBlogPostRepository : GenericRepository<VoteBlogPost, int>,IVoteBlogPostRepository
{
    public VoteBlogPostRepository(BlogAppDbContext context) : base(context)
    {

    }
}
