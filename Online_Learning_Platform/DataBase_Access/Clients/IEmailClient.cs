using DataBase_Access.Services.Models;

namespace FoodManagement_UI.Clients
{
    public interface IEmailClient
    {
        public void Send(MailMessageSettings message);
    }
}