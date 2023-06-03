using System;
using DevFreela.Application.ViewModels;

namespace DevFreela.Application.Services.Interfaces;

public interface IProjectService
{
    List<ProjectViewModel> GetAll(string query);
    List<ProjectDetailsViewModel> GetById(int id);
    int Create(NewsProjectInputModel inputModel);
    void Update(UpdateProjectInputModel inputModel);
    void Delete(int id);
    void CreateComment(CreateCommentInputModel inputModel);
    void Start(int id);
    void Finish(int id);
}

