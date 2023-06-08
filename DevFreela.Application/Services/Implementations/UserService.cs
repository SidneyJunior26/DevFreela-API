using System;
using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;

namespace DevFreela.Application.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly DevFreelaDbContext _dbContext;
        public UserService(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public UserViewModel GetById(int id) {
            var user = _dbContext.Users.SingleOrDefault(u => u.Id == id);

            return new UserViewModel(user.FullName, user.Email, user.Skills, user.OwnedProjects, user.FreelanceProjects);
        }

        public void CreateUser(NewUserInputModel newUserInputModel)
        {
            var newUser = new User(newUserInputModel.FullName, newUserInputModel.Email, newUserInputModel.BirthDate);

            _dbContext.Users.Add(newUser);
        }

        public void Login(int id, LoginInputModel loginModel)
        {
            throw new NotImplementedException();
        }
    }
}

