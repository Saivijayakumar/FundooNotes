//-----------------------------------------------------------------------
// <copyright file="UserController.cs" company="Bridgelabz">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace FundooNotes.Controllers
{
    using System;
    using FundooNotes.Managers.Interface;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    public class UserController : ControllerBase
    {
        private readonly IUserManger manager;

        private readonly ILogger<UserController> _logger;

        public UserController(IUserManger manager, ILogger<UserController> logger)
        {
            this.manager = manager;
            this._logger = logger;
        }

        [HttpPost]
        [Route("api/register")]
        public IActionResult Register([FromBody]RegisterModel userData)
        {
            try
            {
                bool result = this.manager.Register(userData);
                if(result == true)
                {
                    _logger.LogInformation($" A New Register '{userData.Email}' is Successfull Added ");
                    return this.Ok(new { Status = true, Message = "New User Add Successfull your email is : "+userData.Email});
                }
                else
                {
                    _logger.LogInformation($" Register API Fails for : {userData.Email}");
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "User Adding Unsuccessfull.The email is exist already" });
                }
            }
            catch(Exception ex)
            {
                _logger.LogInformation($"Exception Rised for Register : {ex.Message}");
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        [HttpPost]
        [Route("api/Login")]
        public IActionResult Login([FromBody] LoginModel userData)
        {
            try
            {
                bool result = this.manager.Login(userData);
                if (result == true)
                {
                    _logger.LogInformation($"{userData.Email} login successfull");
                    string tokenString = this.manager.GenerateToken(userData.Email);
                    return this.Ok(new  { Status = true, Message ="Login Successfull for :"+userData.Email,newtoken = tokenString});
                }
                else
                {
                    _logger.LogInformation($" Login API Fails for : {userData.Email}");
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Login Unsuccessfull" });
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Exception Rised for Login : {ex.Message}");
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }
        [HttpPost]
        [Route("api/ForgotPassword")]
        public IActionResult ForgotPassword(string email)
        {
            try
            {
                bool result = this.manager.ForgotPassword(email);
                if (result == true)
                {
                    _logger.LogInformation($" Forgot Password Mail send to {email}");
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = "Please check the emial" });
                }
                else
                {
                    _logger.LogInformation($" Forgot Password API Fails for : {email}");
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = " Email incorrect" });
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Exception Rised for Forgot Password : {ex.Message}");
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }
        [HttpPut]
        [Route("api/ResetPassword")]
        public IActionResult ResetPassword([FromBody] ResetPasswordModel resetPasswordData)
        {
            try
            {
                bool result = this.manager.ResetPassword(resetPasswordData);
                if (result == true)
                {
                    _logger.LogInformation($" Reset Password is done for : {resetPasswordData.Email}");
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = "Password Reset Successfull !" });
                }
                else
                {
                    _logger.LogInformation($" Reset Password API Fails for : {resetPasswordData.Email}");
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Password Reset Unsuccessfull!.Invalid ConfirmNewPassword or Invalid Email!" });
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Exception Rised for Reset Password : {ex.Message}");
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }
    }
}
