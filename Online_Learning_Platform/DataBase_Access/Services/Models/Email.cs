using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace DataBase_Access.Services.Models
{
    public class Credentials
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
    }

    public class SmtpClientSettings
    {
        public string? Host { get; set; }
        public int Port { get; set; }
        public bool? EnableSsl { get; set; }
        public Credentials? Credentials { get; set; }
    }

    public class MailMessageSettings
    {
        public MailAddress To { get; set; }
        public string Subject { get; set; }
        public string? Body { get; set; }
    }

    public class AppSettings
    {
        public SmtpClientSettings? SmtpClient { get; set; }
        public MailMessageSettings? MailMessage { get; set; }
    }
}
