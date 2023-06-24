using DevFreela.Infrastructure.Persistence;
using MediatR;

namespace DevFreela.Application.Commands.User.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, Unit>
    {
        private readonly DevFreelaDbContext _dbContext;

        public LoginCommandHandler(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = _dbContext.Users.SingleOrDefault(u => u.Id == request.Id);

            return Unit.Value;
        }
    }
}

