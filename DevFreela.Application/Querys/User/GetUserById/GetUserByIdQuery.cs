using DevFreela.Application.ViewModels;
using MediatR;

namespace DevFreela.Application.Querys.User.GetUserById {
    public class GetUserByIdQuery : IRequest<UserViewModel> {
        public GetUserByIdQuery(int id) {
            Id = id;
        }

        public int Id { get; set; }
    }
}