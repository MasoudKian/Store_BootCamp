﻿using Store_BootCamp.Application.ViewModels.Account;
using Store_BootCamp.Domain.Models.Account;

namespace Store_BootCamp.Application.Services.Interfaces
{
    public interface IUserService
    {
        bool IsExistUserName(string userName);
        bool IsExistEmail(string email);
        User IsEmail(string email);
        int RegisterUser(User user);
        User LoginUser(LoginViewModel loginUser);
        void UpdateUser(User user);
        bool ActiveCode(string activeCode);
        public ICollection<UserViewmodel> GetUsers();
        User GetUserByEmail(ForgotPasswordViewModel forgot);
        User GetUserByActiveCode(string activeCode);
        public void DeleteUser(int id);
        public void FullDeleteUser(int id);
        public User GetById(int id);
        public void EditUser(UserViewmodel userViewmodel);
        public UserViewmodel GetUserById(int id);
        public void saveChanges();

    }
}
