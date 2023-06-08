using System;
using DevFreela.Application.InputModels;
using DevFreela.Application.ViewModels;

namespace DevFreela.Application.Services.Interfaces
{
    public interface IUserService
    {
        UserViewModel GetById(int id);
        void CreateUser(NewUserInputModel newUserInputModel);
        void Login(int id, LoginInputModel loginModel);
    }
}

