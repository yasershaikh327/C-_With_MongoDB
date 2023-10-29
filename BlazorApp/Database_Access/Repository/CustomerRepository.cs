using API.Mapper.DtoMapper.IMapper;
using API.Mapper.UIMapper.IMapper;
using API.Mapper.UIMapper.Model;
using Database_Access.DatabaseManagement;
using Database_Access.IRepository;
using Database_Access.Mapper.UIMapper.IMapper;
using Database_Access.Mapper.UIMapper.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database_Access.Repository
{

    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerOrdersDB _customerOrdersDB;
        private readonly ICustomerDtoMapper _customerDtoMapper;
        private readonly ICustomerMapper _customerMapper;
        private readonly IOrderDtoMapper _orderDtoMapper;
        private readonly IOrderMapper _orderMapper;

        public CustomerRepository(CustomerOrdersDB customerOrdersDB,ICustomerDtoMapper customerDtoMapper,IOrderDtoMapper orderDtoMapper,IOrderMapper orderMapper,ICustomerMapper customerMapper) { 
            _customerOrdersDB = customerOrdersDB;
            _customerDtoMapper = customerDtoMapper;
            _orderDtoMapper = orderDtoMapper;
            _orderMapper = orderMapper;
            _customerMapper = customerMapper;
        }

        //Add Customer
        public void AddCustomer(Customer customer)
        {
            var Dto = _customerDtoMapper.Map(customer);
            {
                _customerOrdersDB.customerDTos.Add(Dto);
                _customerOrdersDB.SaveChanges();
            }
        }


        //Add Order
        public void AddOrders(Order order)
        {
            var Dto = _orderDtoMapper.Map(order);
            {
                _customerOrdersDB.orderDtos.Add(Dto);
                _customerOrdersDB.SaveChanges();
            }
        }

        //Fetch Orders
        public List<Order> GetAllOrders(string Id)
        {
            var orderList = _customerOrdersDB.orderDtos.Where(F => F.Customer_Id == Id).ToList();
            return _orderMapper.Map(orderList);
        }

        //Fetch Customers
        public List<Customer> GetCustomers()
        {
            var customerList = _customerOrdersDB.customerDTos.ToList();
            return _customerMapper.Map(customerList);
        }

    }
}
