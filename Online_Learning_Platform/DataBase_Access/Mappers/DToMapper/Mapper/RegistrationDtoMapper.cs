using DataBase_Access.Mappers.DToMapper.IMapper;
using Online_Learning_Platform.Mappers.UIMapper.Model;

namespace Online_Learning_Platform.Mappers.UIMapper.Mapper
{
    public class RegistrationDtoMapper : IRegistrationDtoMapper
    {
        public RegistrationDto Map(Registration registration)
        {
            var registrationDto = new RegistrationDto();
            registrationDto.Id = registration.Id;
            registrationDto.Name = registration.Name;
            registrationDto.Email = registration.Email;
            registrationDto.Password = registration.Password;
            return registrationDto;
        }

        public class RegistrationDtos
        {
            RegistrationDto registrationDto { get; set; }
            public RegistrationDtos()
            {
                registrationDto = new RegistrationDto();
            }
        }
    }
}
