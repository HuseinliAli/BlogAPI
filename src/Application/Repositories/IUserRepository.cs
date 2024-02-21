using Domain.Entities;

namespace Application.Repositories;

public interface IUserRepository : IGenericRepository<User, Guid>
{
    List<OperationClaim> GetClaims(User user);
}