using DevFreela.Application.ViewModels;
using MediatR;

namespace DevFreela.Application.Querys.Project.GetAllProjects {
    public class GetAllProjectsQuery : IRequest<List<ProjectViewModel>> {
    }
}

