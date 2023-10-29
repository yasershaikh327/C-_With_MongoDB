using API.Mapper.UIMapper.Model;
using Database_Access.Mapper.UIMapper.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database_Access.IRepository
{
    public interface ICustomerRepository
    {
        public void AddCustomer(Customer customer);
        public void AddOrders(Order order);
        public List<Order> GetAllOrders(string Id);
        public List<Customer> GetCustomers();
    }
}
