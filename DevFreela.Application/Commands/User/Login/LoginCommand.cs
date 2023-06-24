using System;
using MediatR;

namespace DevFreela.Application.Commands.User.Login
{
    public class LoginCommand : IRequest<Unit>
    {
        public int Id { get; private set; }

        public LoginCommand(int id)
        {
            Id = id;
        }

        public string UserName { get; set; }
        public string Password { get; set; }
    }
}

