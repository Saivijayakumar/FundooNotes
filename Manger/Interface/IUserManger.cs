//-----------------------------------------------------------------------
// <copyright file="IUserManger.cs" company="Bridgelabz">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace FundooNotes.Managers.Interface
{
    /// <summary>
    /// interface class
    /// </summary>
    public interface IUserManger
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
        /// <param name="Email">Login mail</param>
        /// <returns>JWT token</returns>
        string GenerateToken(string Email);

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
