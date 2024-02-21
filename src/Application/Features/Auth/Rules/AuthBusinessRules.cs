using Application.Repositories;
using Domain.Entities;
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
            User user = userRepository.GetFirst(u=>u.Email==email,false);
        }
    }
}
