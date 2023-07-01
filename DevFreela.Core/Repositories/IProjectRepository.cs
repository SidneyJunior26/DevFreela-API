using System;
using DevFreela.Core.Entities;

namespace DevFreela.Core.Repositories
{
    public interface IProjectRepository
    {
        Task<List<Project>> GetAllAsync();
        Task<Project> GetProjectByIdAsync(int id);
        Task AddAsync(Project project);
        Task RemoveAsync(Project project);
        Task SaveChangesAsync();
        Task CreateComment(ProjectComment projectComment);
    }
}

