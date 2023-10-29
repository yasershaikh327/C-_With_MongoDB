using API.Mapper.DtoMapper.Mapper;
using API.Mapper.DtoMapper.Model;
using API.Mapper.UIMapper.IMapper;
using API.Mapper.UIMapper.Model;

namespace API.Mapper.UIMapper.Mapper
{
    public class CustomerMapper : ICustomerMapper
    {
        //Customer Mapper
        public Customer Map(CustomerDTo customerDTo)
        {
            var customer = new Customer();
            customer.Id = customerDTo.Id;   
            customer.FirstName = customerDTo.FirstName;
            customer.LastName = customerDTo.LastName;   
            customer.DOB = customerDTo.DOB; 
            return customer;
        }

        //List Customer Mapper
        public List<Customer> Map(List<CustomerDTo> customerDTo)
        {
            var Dtos = new List<Customer>();
            foreach(var D in customerDTo)
            {
                var customerItem = new Customer();
                {
                    customerItem.Id = D.Id;
                    customerItem.FirstName = D.FirstName;
                    customerItem.LastName = D.LastName;
                    customerItem.DOB = D.DOB;
                };
                Dtos.Add(customerItem);
            }
            return Dtos;
        }
    }
}
