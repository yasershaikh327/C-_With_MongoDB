using Database_Access.Mapper.UIMapper.Model;

namespace API.Mapper.DtoMapper.Model
{
    public class CustomerDTo
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public List<OrderDto> Orders { get; set; }


    }

    public class CustomerDtos
    {
        public CustomerDTo DTo { get; set; }    
        public CustomerDtos()
        {
            DTo = new CustomerDTo();
        }
    }
}
