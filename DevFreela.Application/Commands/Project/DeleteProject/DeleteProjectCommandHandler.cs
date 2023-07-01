using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using MediatR;

namespace DevFreela.Application.Commands.Project.DeleteProject {
    public class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand, Unit> {
        private readonly IProjectRepository _projectRepository;

        public DeleteProjectCommandHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<Unit> Handle(DeleteProjectCommand request, CancellationToken cancellationToken) {
            var project = await _projectRepository.GetProjectByIdAsync(request.Id);

            if (project != null)
                await _projectRepository.RemoveAsync(project);

            return Unit.Value;
        }
    }
}

