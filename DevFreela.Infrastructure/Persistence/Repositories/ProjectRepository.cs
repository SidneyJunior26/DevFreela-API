﻿using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Infrastructure.Persistence.Repositories {
    public class ProjectRepository : IProjectRepository {
        private readonly DevFreelaDbContext _dbContext;

        public ProjectRepository(DevFreelaDbContext dbContext) {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Project project) {
            await _dbContext.Projects.AddAsync(project);
            await _dbContext.SaveChangesAsync();
        }

        public async Task CreateComment(ProjectComment projectComment) {
            await _dbContext.ProjectComments.AddAsync(projectComment);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Project>> GetAllAsync() {
            return await _dbContext.Projects.ToListAsync();
        }

        public async Task<Project> GetProjectByIdAsync(int id) {
            return await _dbContext.Projects
                .Include(p => p.Client)
                .Include(p => p.Freelancer)
                .SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task RemoveAsync(Project project) {
            _dbContext.Projects.Remove(project);
            await _dbContext.SaveChangesAsync();
        }

        public async Task SaveChangesAsync() {
            await _dbContext.SaveChangesAsync();
        }
    }
}

