using Online_Learning_Platform.Mappers.UIMapper.Model;

namespace DataBase_Access.Mappers.UIMapper.IMapper
{
    public interface IRegistrationMapper
    {
        public Registration Map(RegistrationDto registrationDto);
        public List<Registration> Map(List<RegistrationDto> registrationDto);
    }


}
