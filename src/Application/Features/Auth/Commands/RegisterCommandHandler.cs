using Application.Features.Auth.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auth.Commands
{
    public class RegisterCommand : IRequest<TokenDto>
    {
        public UserRegister UserRegister { get; set; }

        public class RegisterCommandHandler : IRequestHandler<RegisterCommand, TokenDto>
        {
            public Task<TokenDto> Handle(RegisterCommand request, CancellationToken cancellationToken)
            {
                
            }
        }
    }
}
