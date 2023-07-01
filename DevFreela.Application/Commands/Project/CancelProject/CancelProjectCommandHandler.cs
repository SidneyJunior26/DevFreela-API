using DevFreela.Core.Repositories;
using MediatR;

namespace DevFreela.Application.Commands.Project.CancelProject
{
    public class CancelProjectCommandHandler : IRequestHandler<CancelProjectCommand, Unit> {
        private readonly IProjectRepository _projectRepository;

        public CancelProjectCommandHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }


        public async Task<Unit> Handle(CancelProjectCommand request, CancellationToken cancellationToken) {
            var project = await _projectRepository.GetProjectByIdAsync(request.Id);

            project.CancelProject();

            await _projectRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}

