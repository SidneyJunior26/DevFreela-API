using DevFreela.Application.ViewModels;
using DevFreela.Infrastructure.Persistence;
using MediatR;

namespace DevFreela.Application.Querys.User.GetUserById {
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserViewModel> {
        private readonly DevFreelaDbContext _dbContext;
        public GetUserByIdQueryHandler(DevFreelaDbContext dbContext) {
            _dbContext = dbContext;
        }

        public async Task<UserViewModel> Handle(GetUserByIdQuery request, CancellationToken cancellationToken) {
            var user = _dbContext.Users.SingleOrDefault(u => u.Id == request.Id);

            return new UserViewModel(user.FullName, user.Email, user.Skills, user.OwnedProjects, user.FreelanceProjects);
        }
    }
}