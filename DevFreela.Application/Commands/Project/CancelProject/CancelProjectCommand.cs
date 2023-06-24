using MediatR;

namespace DevFreela.Application.Commands.Project.CancelProject
{
    public class CancelProjectCommand : IRequest<Unit>
    {
        public CancelProjectCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}

