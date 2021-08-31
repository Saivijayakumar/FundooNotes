using Experimental.System.Messaging;
using FundooNotes.Models;
using FundooNotes.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Models;
using Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace FundooNotes.Repository.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext userContext;

        public UserRepository(UserContext userContext)
        {
            this.userContext = userContext;

        }
        public bool Register(RegisterModel userData)
        {
            try
            {
                if(userData != null)
                {
                    userData.Password = EncodePasswordToBase64(userData.Password);
                    this.userContext.Users.Add(userData);
                    this.userContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch(ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }
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
        public bool ForgotPassword(string email)
        {
            try
            {
                var userCheck = this.userContext.Users.Where(x => x.Email == email).FirstOrDefault();
                if (userCheck != null)
                {
                    SendMessageToMAMQ();
                    var msgBody = receiveMessageFromMAMQ();
                    MailMessage mailMessage = new MailMessage("FromEmail", email);
                    mailMessage.Subject = "Link For reset Password";
                    mailMessage.Body = msgBody;
                    mailMessage.IsBodyHtml = true;
                    SmtpClient Smtp = new SmtpClient();
                    Smtp.Host = "smtp.gmail.com";
                    Smtp.EnableSsl = true;
                    Smtp.UseDefaultCredentials = false;
                    Smtp.Credentials = new NetworkCredential("FromEmail", "FromEmailPassword");
                    Smtp.Port = 587;
                    Smtp.Send(mailMessage);
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        // It help to send and store the message in MAMQ(Microsoft Messaging Queue)
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
        // It help to receive and return the message from MAMQ(Microsoft Messaging Queue)
        public static string receiveMessageFromMAMQ()
        {
            MessageQueue receiveQueue = new MessageQueue(@".\Private$\MyQueue");
            var receivemsg = receiveQueue.Receive();
            receivemsg.Formatter = new BinaryMessageFormatter();
            string linkToBeSend = receivemsg.Body.ToString();
            return linkToBeSend;
        }
        public bool ResetPassword(ResetPasswordModel resetPasswordData)
        {
            try
            {
                string encodedPassword = EncodePasswordToBase64(resetPasswordData.NewPassword);
                var userPresent = this.userContext.Users.Where(x => x.Email == resetPasswordData.Email).FirstOrDefault();
                if (userPresent != null && resetPasswordData.ConfirmNewPassword == resetPasswordData.NewPassword)
                {
                    userPresent.Password = encodedPassword;
                    userContext.Entry(userPresent).State = EntityState.Modified;
                    userContext.SaveChanges();
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
