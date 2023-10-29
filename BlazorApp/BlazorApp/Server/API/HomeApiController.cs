using API.Mapper.UIMapper.Model;
using Database_Access.IRepository;
using Database_Access.Mapper.UIMapper.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.API
{
    [ApiController]
    [Route("[controller]/[Action]")]
    public class HomeApiController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        public HomeApiController(ICustomerRepository customerRepository) { 
            _customerRepository = customerRepository;
        }

        //Add Customer
        [HttpPost]
        public void AddCustomer(Customer customer)
        {
            _customerRepository.AddCustomer(customer);
        }


        //Add Orders
        [HttpPost]
        public void AddOrders(Order order)
        {
            _customerRepository.AddOrders(order);
        }

        
        //Get Orders
        [HttpGet]
        public IEnumerable<Order> GetOrders(string Id)
        {
           return _customerRepository.GetAllOrders(Id);
        }

        //Get Customers
        [HttpGet]
        public IEnumerable<Customer> GetCustomers()
        {
            return _customerRepository.GetCustomers();
        }

    }
}
