using Domain.Entities;

namespace Application.Utils.Jwt;

public interface ITokenHelper
{
    Task<AccessToken> CreateToken(User user,List<OperationClaim> operationClaims);
    
}

