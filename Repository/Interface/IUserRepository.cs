using FundooNotes.Models;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundooNotes.Repository.Interface
{
    public interface IUserRepository
    {
        bool Register(RegisterModel userData);
        bool Login(LoginModel userData);
        bool ForgotPassword(string email);
        bool ResetPassword(ResetPasswordModel resetPasswordData);
    }
}
