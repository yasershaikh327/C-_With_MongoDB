using DataBase_Access.Services.Models;
using FoodManagement_UI.Clients;
using System.Net.Mail;

namespace FoodManagement_UI.Services
{
    public class EmailService : IEmailService
    {
        private readonly IEmailClient _emailClient;

        public EmailService(IEmailClient emailClient)
        {
            _emailClient = emailClient;
        }
        public void SendMail(MailMessageSettings mailMessageSettings)
        {
            try
            {
                var mailMessage = new MailMessageSettings
                {
                    Body = mailMessageSettings.Body,
                    To = mailMessageSettings.To,
                };
                _emailClient.Send(mailMessage);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error sending email: " + ex.Message);
            }
        }

        //Contact Us
        public void Contact(string email)
        {
            var mailMessage = new MailMessageSettings();
            mailMessage.To = new MailAddress(email);
            mailMessage.Body = "Thank You For Contacting Us";
            SendMail(mailMessage);
        }


        //Reply Back
        public void ReplyBack(string email, string reply)
        {
            var mailMessage = new MailMessageSettings();
            mailMessage.To = new MailAddress(email);
            mailMessage.Body = reply;
            SendMail(mailMessage);
        }

        //Recover Password
        public void Recover(string email,string RecoverPassword)
        {
            var mailMessage = new MailMessageSettings();
            mailMessage.To = new MailAddress(email);
            mailMessage.Body = RecoverPassword;
            SendMail(mailMessage);
        }
    }
}