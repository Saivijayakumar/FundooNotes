//-----------------------------------------------------------------------
// <copyright file="UserController.cs" company="Bridgelabz">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
using FundooNotes.Managers.Interface;
using FundooNotes.Repository.Interface;
using System;

namespace FundooNotes.Managers.Manger
{
    public class UserManager : IUserManger
    {
        private readonly IUserRepository repository;
        public  UserManager(IUserRepository repository)
        {
            this.repository = repository;
        }
        public bool Register(RegisterModel userData)
        {
            try
            {
                return this.repository.Register(userData);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool Login(LoginModel userData)
        {
            try
            {
                return this.repository.Login(userData);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool ForgotPassword(string email)
        {
            try
            {
                return this.repository.ForgotPassword(email);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool ResetPassword(ResetPasswordModel resetPasswordData)
        {
            try
            {
                return this.repository.ResetPassword(resetPasswordData);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
