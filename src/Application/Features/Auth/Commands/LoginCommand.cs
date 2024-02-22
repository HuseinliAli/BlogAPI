using Application.Features.Auth.Dtos;
using Application.Features.Auth.Rules;
using Application.Repositories;
using Application.Utils.Jwt;
using Domain.Entities;
using MediatR;
using System.Security.Cryptography;

namespace Application.Features.Auth.Commands
{
    public class LoginCommand : IRequest<TokenDto>
    {
        public UserLoginDto UserLoginDto { get; set; }

        public class LoginCommandHandler(AuthBusinessRules businessRules, IUserRepository userRepository, ITokenHelper tokenService) : IRequestHandler<LoginCommand, TokenDto>
        {
            public async Task<TokenDto> Handle(LoginCommand request, CancellationToken cancellationToken)
            {
                User user =await  userRepository.GetFirst(u=>u.Email==request.UserLoginDto.Email,true);
                await businessRules.VerifyUser(request.UserLoginDto.Email, request.UserLoginDto.Password);
                
                var accessToken = await tokenService.CreateToken(user, GetClaims(user));

                user.RefreshToken = GenerateRefreshToken();
                user.RefreshTokenExpiryTime = DateTime.Now.AddDays(7);
                await userRepository.SaveChangesAsync();

                return new()
                {
                    AccessToken=accessToken.Token,
                    RefreshToken=user.RefreshToken
                };
            }
         
            private List<OperationClaim> GetClaims(User user)
            {
                return userRepository.GetClaims(user);
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
    }
}
