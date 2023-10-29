using DataBase_Access.Services.Models;

namespace FoodManagement_UI.Services
{
    public interface IEmailService
    {
        public void SendMail(MailMessageSettings mailMessageSettings);
        public void Contact(string email);
        public void ReplyBack(string email,string reply);
        public void Recover(string email, string RecoverPassword);
    }
}