using DevFreela.Application.ViewModels;
using MediatR;

namespace DevFreela.Application.Querys.Project.GetProjectById {
    public class GetProjectByIdCommand : IRequest<ProjectDetailsViewModel> {
        public int Id { get; set; }
    }
}