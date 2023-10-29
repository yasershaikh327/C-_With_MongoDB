using API.Mapper.DtoMapper.IMapper;
using API.Mapper.DtoMapper.Model;
using API.Mapper.UIMapper.Model;

namespace API.Mapper.DtoMapper.Mapper
{
    public class CustomerDtoMapper : ICustomerDtoMapper
    {
        //Map
        public CustomerDTo Map(Customer customer)
        {
            var Dto = new CustomerDTo();
            Dto.Id = customer.Id;
            Dto.FirstName = customer.FirstName;
            Dto.LastName = customer.LastName;
            Dto.DOB = customer.DOB;
            return Dto;
        }
    }
}
