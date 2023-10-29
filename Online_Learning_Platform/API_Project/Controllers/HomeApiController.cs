using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Online_Learning_Platform.Mappers.UIMapper.Mapper;
using Online_Learning_Platform.Mappers.UIMapper.Model;

namespace API_Project.Controllers
{
    [ApiController]
    [Route("[controller]/[Action]")]
    public class HomeApiController : ControllerBase
    {
        private readonly IRegistrationMapper _registrationMapper;
        public HomeApiController(IRegistrationMapper registrationMapper) { 
            _registrationMapper = registrationMapper;
        
        }


        [HttpPost]
        public void Registration(Registration registration)
        {
            Console.WriteLine(registration);
        }
    }
}
