//-----------------------------------------------------------------------
// <copyright file="UserRepository.cs" company="Bridgelabz">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace FundooNotes.Repository.Repository
{
    using System;
    using System.Linq;
    using System.Net;
    using System.Net.Mail;
    using Experimental.System.Messaging;
    using FundooNotes.Repository.Context;
    using FundooNotes.Repository.Interface;
    using Microsoft.EntityFrameworkCore;

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
        /// Initializes a new instance of the <see cref="UserRepository" /> class
        /// </summary>
        /// <param name="userContext">sending Object</param>
        public UserRepository(UserContext userContext)
        {
            this.userContext = userContext;
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
            var url = "If you want to Rest your credentials for Fundoonotes App Please Click on the link  https://localhost:44338/api/ResetPassword";
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
            messageQueue.Label = "First url link";
            messageQueue.Send(message);
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
                if (userData != null)
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
                    var msgBody = ReceiveMessageFromMAMQ();
                    MailMessage mailMessage = new MailMessage("FromEmail", email);
                    mailMessage.Subject = "Link For reset Password";
                    mailMessage.Body = msgBody;
                    mailMessage.IsBodyHtml = true;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.EnableSsl = true;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential("FromEmail", "FromEmailPassword");
                    smtp.Port = 587;
                    smtp.Send(mailMessage);
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
    }
}
