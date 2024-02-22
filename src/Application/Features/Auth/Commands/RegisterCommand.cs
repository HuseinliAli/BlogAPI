using Application.Features.Auth.Dtos;
using Application.Features.Auth.Rules;
using Application.Repositories;
using Application.Utils.Hashing;
using Application.Utils.Jwt;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auth.Commands
{
    public  class RegisterCommand : IRequest<TokenDto>
    {
        public UserRegisterDto UserRegisterDto { get; set; }

        public class RegisterCommandHandler(AuthBusinessRules businessRules,IUserRepository userRepository,ITokenHelper tokenService) : IRequestHandler<RegisterCommand, TokenDto>
        {
            public async Task<TokenDto> Handle(RegisterCommand request, CancellationToken cancellationToken)
            {
                await businessRules.EmailIsDublicated(request.UserRegisterDto.Email);

                byte[] hash, salt;
                HashingHelper.CreatePasswordHash(request.UserRegisterDto.Password, out hash, out salt);

                User createdUser = new()
                {
                    Email=request.UserRegisterDto.Email,
                    PasswordHash=hash,
                    PasswordSalt=salt,
                    FirstName=request.UserRegisterDto.FirstName,
                    LastName=request.UserRegisterDto.LastName,
                    RefreshToken = GenerateRefreshToken(),
                    RefreshTokenExpiryTime=DateTime.Now.AddDays(7)
                };
                userRepository.Add(createdUser);
                await userRepository.SaveChangesAsync();
                var accessToken = await tokenService.CreateToken(createdUser,GetClaims(createdUser));
                return new TokenDto() { AccessToken=accessToken.Token, RefreshToken=createdUser.RefreshToken };
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
