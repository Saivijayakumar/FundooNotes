//-----------------------------------------------------------------------
// <copyright file="IUserRepository.cs" company="Bridgelabz">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace FundooNotes.Repository.Interface
{
    /// <summary>
    /// Instance class
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Register method 
        /// </summary>
        /// <param name="userData">It contain all data of user</param>
        /// <returns>true or false</returns>
        bool Register(RegisterModel userData);

        /// <summary>
        /// Login method 
        /// </summary>
        /// <param name="userData">It contain email and password</param>
        /// <returns>true or false</returns>
        bool Login(LoginModel userData);

        /// <summary>
        /// Generate Token
        /// </summary>
        /// <param name="email">Login mail</param>
        /// <returns>JWT token</returns>
        string GenerateToken(string email);

        /// <summary>
        /// we will send mail to 
        /// </summary>
        /// <param name="email">email only</param>
        /// <returns>true or false</returns>
        bool ForgotPassword(string email);

        /// <summary>
        /// Reset the password
        /// </summary>
        /// <param name="resetPasswordData">email,new password and ConfirmNewPassword</param>
        /// <returns>true or false</returns>
        bool ResetPassword(ResetPasswordModel resetPasswordData);
    }
}
