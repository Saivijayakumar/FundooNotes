//-----------------------------------------------------------------------
// <copyright file="IUserManger.cs" company="Bridgelabz">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace FundooNotes.Managers.Interface
{
     public interface IUserManger
     {
        bool Register(RegisterModel userData);
        bool Login(LoginModel userData);
        string GenerateToken(string Email);
        bool ForgotPassword(string email);
        bool ResetPassword(ResetPasswordModel resetPasswordData);
    }
}
