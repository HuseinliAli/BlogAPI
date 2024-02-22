using Application.Features.Auth.Dtos;
using Application.Repositories;
using Application.Utils.Hashing;
using Domain.Entities;
using Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auth.Rules
{
    public class AuthBusinessRules(IUserRepository userRepository)
    {
        public async Task EmailIsDublicated(string email)
        {
            User user = await userRepository.GetFirst(u => u.Email==email, false);
            if (user is not null)
                throw new EmailCannotBeDublicatedException();
        }

        public async Task VerifyUser(string email,string password)
        { 
            User user = await userRepository.GetFirst(u => u.Email==email, false);

            if(email!=user.Email || !HashingHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                throw new EmailOrUserWrongException();
            
        }

        public async Task CheckUserExists(Guid id)
        {
            User user  = await userRepository.GetFirst(u=>u.Id.Equals(id), false);
            if (user is null)
                throw new NotFoundByIdException<Guid>(id);
        }

    }
}
