using API.Mapper.DtoMapper.Model;
using API.Mapper.UIMapper.Model;

namespace API.Mapper.DtoMapper.IMapper
{
    public interface ICustomerDtoMapper
    {
        CustomerDTo Map(Customer customer);
    }
}
