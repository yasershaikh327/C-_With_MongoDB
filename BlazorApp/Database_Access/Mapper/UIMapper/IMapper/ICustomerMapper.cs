using API.Mapper.DtoMapper.Mapper;
using API.Mapper.DtoMapper.Model;
using API.Mapper.UIMapper.Model;

namespace API.Mapper.UIMapper.IMapper
{
    public interface ICustomerMapper
    {
        public Customer Map(CustomerDTo customerDTo);
        public List<Customer> Map(List<CustomerDTo> customerDTo);
    }
}
