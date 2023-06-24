using DevFreela.Application.ViewModels;
using MediatR;

namespace DevFreela.Application.Querys.Skills.GetAllSkills {
    public class GetAllSkillsQuery : IRequest<List<SkillViewModel>> {

    }
}

