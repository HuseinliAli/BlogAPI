using Application.Utils.Encryption;
using Application.Utils.Extensions;
using Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace Application.Utils.Jwt;

public class JwtHelper : ITokenHelper
{
    public IConfiguration Configuration { get; }
    private TokenOptions _tokenOptions;
    private DateTime _accessTokenExpiration;
    public JwtHelper(IConfiguration configuration)
    {
        Configuration=configuration;
        _tokenOptions=new();
        var jwtSettings = Configuration.GetSection("JwtSettings");
        _tokenOptions.Issuer = jwtSettings["Issuer"];
        _tokenOptions.Audience = jwtSettings["Audience"];
        _tokenOptions.SecurityKey = jwtSettings["SecurityKey"];
        _tokenOptions.Expires = int.Parse(jwtSettings["Expires"]);
    }
    public async Task<AccessToken> CreateToken(User user, List<OperationClaim> operationClaims)
    {
        _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.Expires);
        var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
        var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
        var jwt = CreateJwtToken(_tokenOptions, user, signingCredentials, operationClaims);
        var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        var token = jwtSecurityTokenHandler.WriteToken(jwt);

        return new AccessToken
        {
            Token = token,
            Expires = _accessTokenExpiration
        };

    }

    public  JwtSecurityToken CreateJwtToken(TokenOptions tokenOptions,User user, SigningCredentials signingCredentials, List<OperationClaim> operationClaims)
    {
        var jwt = new JwtSecurityToken(
            issuer:tokenOptions.Issuer,
            audience:tokenOptions.Audience,
            expires:DateTime.MinValue,
            notBefore:DateTime.Now,
            claims:SetClaims(user,operationClaims),
            signingCredentials:signingCredentials
            );
        return jwt;
    }

    private IEnumerable<Claim> SetClaims(User user, List<OperationClaim> operationClaims)
    {
        var claims = new List<Claim>();
        claims.AddNameIdentifier(user.Id.ToString());
        claims.AddEmail(user.Email);
        claims.AddName($"{user.FirstName} {user.LastName}");
        claims.AddRoles(operationClaims.Select(c => c.Name).ToArray());
        return claims;
    }

    private string GenerateRefreshToken()
    {
        var randomNumber = new byte[32];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);  
        }
    }
}

