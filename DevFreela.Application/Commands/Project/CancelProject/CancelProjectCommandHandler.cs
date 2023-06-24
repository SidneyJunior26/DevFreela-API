using DevFreela.Infrastructure.Persistence;
using MediatR;

namespace DevFreela.Application.Commands.Project.CancelProject {
    public class CancelProjectCommandHandler : IRequestHandler<CancelProjectCommand, Unit> {
        private readonly DevFreelaDbContext _dbContext;

        public CancelProjectCommandHandler(DevFreelaDbContext dbContext) {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(CancelProjectCommand request, CancellationToken cancellationToken) {
            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == request.Id);

            if (project != null)
                project.CancelProject();

            await _dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}

