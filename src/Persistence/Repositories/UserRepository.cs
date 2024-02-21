using Application.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class UserRepository : GenericRepository<User, Guid>, IUserRepository
{
    private readonly BlogAppDbContext _context;
    public UserRepository(BlogAppDbContext context):base(context)
    {
        _context=context;
    }

    public List<OperationClaim> GetClaims(User user)
    {
        var result = from oc in _context.OperationClaims
                     join uoc in _context.UserOperations
                     on oc.Id equals uoc.OperationClaimId
                     where uoc.UserId == user.Id
                     select new OperationClaim { Id = oc.Id, Name=oc.Name };
        return result.ToList();
    }
}