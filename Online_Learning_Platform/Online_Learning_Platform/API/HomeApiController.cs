
using DataBase_Access.Helper;
using DataBase_Access.IRepository;
using DataBase_Access.Mappers.UIMapper.Model;
using Microsoft.AspNetCore.Mvc;
using Online_Learning_Platform.Mappers.UIMapper.Model;

namespace Online_Learning_Platform.ApiControllers
{
    [ApiController]
    [Route("[controller]/[Action]")]
    public class HomeApiController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IHelper _helper;

        public HomeApiController(IUserRepository userRepository,IHelper helper) {
            _userRepository = userRepository;
            _helper = helper;
        }


        [HttpPost]
        //Registration
        public void Registration(Registration registration)
        {
            _userRepository.AddUsers(registration);
        }

        [HttpPost]
        //Check if Email Exists
        public bool CheckEmailExists(string Email)
        {
           return _userRepository.CheckIfUSerExists(Email);
        }


        //Login Process
        [HttpPost]
        public int ConfirmLogin(Login login)
        {
            int isUserAuthenticated = _helper.IsUserAuthenticated(login);
            if (isUserAuthenticated == -2)
                return -2;
            return _userRepository.LoginProcess(login);
        }

        //Contact US
        [HttpPost]
        public void Contacts(Contact contact)
        {
            _userRepository.ContactUs(contact);
        }

        //Recover Password
        public void RecoverPassword(string Email)
        {
            _userRepository.RecoverViaEmail(Email);
        }

    }
}
