//-----------------------------------------------------------------------
// <copyright file="UserManager.cs" company="Bridgelabz">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace FundooNotes.Managers.Manger
{
    using FundooNotes.Managers.Interface;
    using FundooNotes.Repository.Interface;
    using System;

    public class UserManager : IUserManger
    {
        /// <summary>
        /// IUserRepository object Initialize
        /// </summary>
        private readonly IUserRepository repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserManager" /> class
        /// </summary>
        /// <param name="repository">object name</param>
        public UserManager(IUserRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Register method 
        /// </summary>
        /// <param name="userData">It contain all data of user</param>
        /// <returns>true or false</returns>
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

        /// <summary>
        /// Login method 
        /// </summary>
        /// <param name="userData">It contain email and password</param>
        /// <returns>true or false</returns>
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

        /// <summary>
        /// Generate Token
        /// </summary>
        /// <param name="Email">Login mail</param>
        /// <returns>JWT token</returns>
        public string GenerateToken(string Email)
        {
            try
            {
                return this.repository.GenerateToken(Email);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// we will send mail to 
        /// </summary>
        /// <param name="email">email only</param>
        /// <returns>true or false</returns>
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

        /// <summary>
        /// Reset the password
        /// </summary>
        /// <param name="resetPasswordData">email,new password and ConfirmNewPassword</param>
        /// <returns>true or false</returns>
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
