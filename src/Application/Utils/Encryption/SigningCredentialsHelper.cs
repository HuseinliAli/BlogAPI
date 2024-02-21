using Microsoft.IdentityModel.Tokens;

namespace Application.Utils.Encryption;
public static class SigningCredentialsHelper
{
    public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)
    {

        return new(securityKey, SecurityAlgorithms.HmacSha512Signature);
    }
}