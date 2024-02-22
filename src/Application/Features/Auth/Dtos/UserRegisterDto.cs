using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auth.Dtos
{
    public record UserRegisterDto(string FirstName,string LastName,string Email,string Password);
}
