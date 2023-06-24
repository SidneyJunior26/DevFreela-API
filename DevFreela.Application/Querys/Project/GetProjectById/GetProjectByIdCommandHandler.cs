using DevFreela.Application.ViewModels;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Querys.Project.GetProjectById {
    public class GetProjectByIdCommandHandler : IRequestHandler<GetProjectByIdCommand, ProjectDetailsViewModel> {
        private readonly IProjectRepository _projectRepository;

        public GetProjectByIdCommandHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<ProjectDetailsViewModel> Handle(GetProjectByIdCommand request, CancellationToken cancellationToken) {
            var project = _projectRepository.GetProjectById(request.Id);

            return new ProjectDetailsViewModel(project.Title, project.Description, project.TotalCost, project.Status,
                project.Client.FullName, project.Freelancer.FullName);
        }
    }
}

