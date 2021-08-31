//-----------------------------------------------------------------------
// <copyright file="UserController.cs" company="Bridgelabz">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace FundooNotes.Managers.Interface
{
     public interface IUserManger
     {
        bool Register(RegisterModel userData);
        bool Login(LoginModel userData);
        bool ForgotPassword(string email);
        bool ResetPassword(ResetPasswordModel resetPasswordData);
    }
}
