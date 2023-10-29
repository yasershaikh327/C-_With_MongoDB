using DataBase_Access.Services.Models;
using Microsoft.Extensions.Configuration;
using System.Net.Mail;

namespace FoodManagement_UI.Clients
{
    public class EmailClient : IEmailClient
    {
        private readonly IConfiguration _configuration;
        private readonly SmtpClient _smtpClient;

        public EmailClient(IConfiguration configuration)
        {
            _configuration = configuration;
            var smtpClientSettings = _configuration.GetSection("SmtpClientSettings");
            var credentials = _configuration.GetSection("SmtpClientSettings:Credentials");
            _smtpClient = new SmtpClient(smtpClientSettings["Host"]);
            _smtpClient.Port = Convert.ToInt32(smtpClientSettings["Port"]);
            _smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            _smtpClient.UseDefaultCredentials = false;
            _smtpClient.EnableSsl = true;
            _smtpClient.Credentials = new System.Net.NetworkCredential(credentials["Username"], credentials["Password"]);

        }

        public void Send(MailMessageSettings mailSettingMessage)
        {
            var mailMessageConfig = _configuration.GetSection("MailMessage");
            var Email = new MailAddress("syaser327@outlook.com");
            MailMessage mailMessage = new MailMessage(Email,mailSettingMessage.To);
            mailMessage.Subject = mailMessageConfig["Subject"];
            mailMessage.Body = mailSettingMessage.Body;
            mailMessage.IsBodyHtml = true;
            _smtpClient.Send(mailMessage);
        }
    }
}
