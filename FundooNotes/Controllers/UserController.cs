//-----------------------------------------------------------------------
// <copyright file="UserController.cs" company="Bridgelabz">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace FundooNotes.Controllers
{
    using System;
    using FundooNotes.Managers.Interface;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using StackExchange.Redis;

    /// <summary>
    /// UserController Class
    /// </summary>
    public class UserController : ControllerBase
    {
        /// <summary>
        /// Object for IUserManger
        /// </summary>
        private readonly IUserManger manager;

        /// <summary>
        /// Object for Logger
        /// </summary>
        private readonly ILogger<UserController> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserController" /> class
        /// </summary>
        /// <param name="manager">Initialize object for manager</param>
        /// <param name="logger">Initialize object for logger</param>
        public UserController(IUserManger manager, ILogger<UserController> logger)
        {
            this.manager = manager;
            this.logger = logger;
        }

        /// <summary>
        /// Register New User
        /// </summary>
        /// <param name="userData">User Data</param>
        /// <returns>IAction Result</returns>
        [HttpPost]
        [Route("api/register")]
        public IActionResult Register([FromBody]RegisterModel userData)
        {
            try
            {
                string sessionFirstName = string.Empty;
                string sessionEmail = string.Empty;
                bool result = this.manager.Register(userData);
                if (result == true)
                {
                    this.logger.LogInformation($" A New Register '{userData.Email}' is Successfull Added ");
                    HttpContext.Session.SetString(sessionFirstName, userData.FirstName);
                    HttpContext.Session.SetString(sessionEmail, userData.Email);
                    return this.Ok(new { Status = true, Message = "New User Add Successfull your email is : " + userData.Email });
                }
                else
                {
                    this.logger.LogInformation($" Register API Fails for : {userData.Email}");
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "User Adding Unsuccessfull.The email is exist already" });
                }
            }
            catch (Exception ex)
            {
                this.logger.LogInformation($"Exception Rised for Register : {ex.Message}");
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Login to account
        /// </summary>
        /// <param name="userData">Login Data</param>
        /// <returns>IAction Result</returns>
        [HttpPost]
        [Route("api/Login")]
        public IActionResult Login([FromBody] LoginModel userData)
        {
            try
            {
                bool result = this.manager.Login(userData);
                if (result == true)
                {
                    ConnectionMultiplexer connectionMultiplexer = ConnectionMultiplexer.Connect("127.0.0.1:6379");
                    IDatabase database = connectionMultiplexer.GetDatabase();
                    string firstName = database.StringGet("FirstName");
                    string lastName = database.StringGet("LastName");
                    int userId = Convert.ToInt32(database.StringGet("UserId"));

                    this.logger.LogInformation($"{userData.Email} login successfull");
                    string tokenString = this.manager.GenerateToken(userData.Email);
                    return this.Ok(new { Status = true, Message = "Login Successfull for :" + userData.Email, newtoken = tokenString });
                }
                else
                {
                    this.logger.LogInformation($" Login API Fails for : {userData.Email}");
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Login Unsuccessfull" });
                }
            }
            catch (Exception ex)
            {
                this.logger.LogInformation($"Exception Rised for Login : {ex.Message}");
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// API for Forgot Password
        /// </summary>
        /// <param name="email">Get Email</param>
        /// <returns>IAction Result</returns>
        [HttpPost]
        [Route("api/ForgotPassword")]
        public IActionResult ForgotPassword(string email)
        {
            try
            {
                bool result = this.manager.ForgotPassword(email);
                if (result == true)
                {
                    this.logger.LogInformation($" Forgot Password Mail send to {email}");
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = "Please check the emial" });
                }
                else
                {
                    this.logger.LogInformation($" Forgot Password API Fails for : {email}");
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = " Email incorrect" });
                }
            }
            catch (Exception ex)
            {
                this.logger.LogInformation($"Exception Rised for Forgot Password : {ex.Message}");
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Reset the password
        /// </summary>
        /// <param name="resetPasswordData">Getting mail for reset</param>
        /// <returns>IAction Result</returns>
        [HttpPut]
        [Route("api/ResetPassword")]
        public IActionResult ResetPassword([FromBody] ResetPasswordModel resetPasswordData)
        {
            try
            {
                bool result = this.manager.ResetPassword(resetPasswordData);
                if (result == true)
                {
                    this.logger.LogInformation($" Reset Password is done for : {resetPasswordData.Email}");
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = "Password Reset Successfull !" });
                }
                else
                {
                    this.logger.LogInformation($" Reset Password API Fails for : {resetPasswordData.Email}");
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Password Reset Unsuccessfull!.Invalid ConfirmNewPassword or Invalid Email!" });
                }
            }
            catch (Exception ex)
            {
                this.logger.LogInformation($"Exception Rised for Reset Password : {ex.Message}");
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }
    }
}
