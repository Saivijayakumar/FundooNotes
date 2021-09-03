//-----------------------------------------------------------------------
// <copyright file="UserRepository.cs" company="Bridgelabz">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace FundooNotes.Repository.Repository
{
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.Linq;
    using System.Net;
    using System.Net.Mail;
    using System.Security.Claims;
    using System.Text;
    using Experimental.System.Messaging;
    using FundooNotes.Repository.Context;
    using FundooNotes.Repository.Interface;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.IdentityModel.Tokens;

    /// <summary>
    /// UserRepository class 
    /// </summary>
    public class UserRepository : IUserRepository
    {
        /// <summary>
        /// Object for UserContext
        /// </summary>
        private readonly UserContext userContext;

        /// <summary>
        /// this object is used to access the data of SecretKey from app settings
        /// </summary>
        private readonly IConfiguration configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepository" /> class
        /// </summary>
        /// <param name="userContext">Database object</param>
        /// <param name="configuration">AppSetting object</param>
        public UserRepository(UserContext userContext, IConfiguration configuration)
        {
            this.userContext = userContext;
            this.configuration = configuration;
        }

        /// <summary>
        /// Here we will encrypt the password
        /// </summary>
        /// <param name="password">password in string</param>
        /// <returns>encrypt password</returns>
        public static string EncodePasswordToBase64(string password)
        {
            try
            {
                byte[] encData_byte = new byte[password.Length];
                encData_byte = System.Text.Encoding.UTF8.GetBytes(password);
                string encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Encode" + ex.Message);
            }
        }

        /// <summary>
        /// It help to receive and return the message from MAMQ(Microsoft Messaging Queue)
        /// </summary>
        /// <returns>Data as a string</returns>
        public static string ReceiveMessageFromMAMQ()
        {
            MessageQueue receiveQueue = new MessageQueue(@".\Private$\MyQueue");
            var receivemsg = receiveQueue.Receive();
            receivemsg.Formatter = new BinaryMessageFormatter();
            string linkToBeSend = receivemsg.Body.ToString();
            return linkToBeSend;
        }

        /// <summary>
        /// It help to send and store the message in MAMQ(Microsoft Messaging Queue)
        /// </summary>
        public static void SendMessageToMAMQ()
        {
            var url = "If you want to Rest your credentials for Fundoonotes App Please Click on the link";
            MessageQueue messageQueue = new MessageQueue();
            if (MessageQueue.Exists(@".\Private$\MyQueue"))
            {
                messageQueue = new MessageQueue(@".\Private$\MyQueue");
            }
            else
            {
                messageQueue = MessageQueue.Create(@".\Private$\MyQueue");
            }

            Message message = new Message();
            message.Formatter = new BinaryMessageFormatter();
            message.Body = url;
            messageQueue.Send(message);
        }
        
        /// <summary>
        /// In method we receive data form queue and send mail 
        /// </summary>
        /// <param name="email">To mail</param>
        public static void SendMail(string email)
        {
            try
            {
                var msgBody = ReceiveMessageFromMAMQ();
                MailMessage mailMessage = new MailMessage("FromEmail", email);
                mailMessage.Subject = "Link For reset Password";
                mailMessage.Body = msgBody;
                mailMessage.IsBodyHtml = true;
                SmtpClient smtpClient = new SmtpClient();
                smtpClient.Port = 587;
                smtpClient.Host = "smtp.gmail.com";
                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential("FromEmail", "FromEmailPassword");
                smtpClient.Send(mailMessage);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
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
                bool personPresent = this.userContext.Users.Any(x => x.Email == userData.Email);
                if (userData != null && personPresent == false)
                {
                    userData.Password = EncodePasswordToBase64(userData.Password);
                    this.userContext.Users.Add(userData);
                    this.userContext.SaveChanges();
                    return true;
                }

                return false;
            }
            catch (ArgumentNullException ex)
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
                string encodedPassword = EncodePasswordToBase64(userData.Password);
                var loginResult = this.userContext.Users.Where(x => x.Email == userData.Email && x.Password == encodedPassword).FirstOrDefault();
                if (loginResult != null)
                {
                    return true;
                }

                return false;
            }
            catch (ArgumentNullException ex)
            {
                throw new ArgumentNullException(ex.Message);
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
                var userCheck = this.userContext.Users.Where(x => x.Email == email).FirstOrDefault();
                if (userCheck != null)
                {
                    SendMessageToMAMQ();
                    SendMail(email);
                    return true;
                }
                else
                {
                    return false;
                }
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
                string encodedPassword = EncodePasswordToBase64(resetPasswordData.NewPassword);
                var userPresent = this.userContext.Users.Where(x => x.Email == resetPasswordData.Email).FirstOrDefault();
                if (userPresent != null && resetPasswordData.ConfirmNewPassword == resetPasswordData.NewPassword)
                {
                    userPresent.Password = encodedPassword;
                    this.userContext.Entry(userPresent).State = EntityState.Modified;
                    this.userContext.SaveChanges();
                    return true;
                }

                return false;
            }
            catch (ArgumentNullException ex)
            {
                throw new ArgumentNullException(ex.Message);
            }
        }

        /// <summary>
        /// In this method we are having Header and payload part just getting SecretKey from outside.
        /// </summary>
        /// <param name="email">one of payload data</param>
        /// <returns>Token string</returns>
        public string GenerateToken(string email)
        {
            byte[] key = Encoding.UTF8.GetBytes(this.configuration["SecretKey"]);
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(key);
            SecurityTokenDescriptor descriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] 
            {
                new Claim(ClaimTypes.Name, email)
            }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature)
            };
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            JwtSecurityToken token = handler.CreateJwtSecurityToken(descriptor);
            return handler.WriteToken(token);
        }
    }
}
