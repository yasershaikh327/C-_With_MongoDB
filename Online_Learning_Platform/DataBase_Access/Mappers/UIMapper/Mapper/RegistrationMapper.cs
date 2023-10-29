using DataBase_Access.Mappers.UIMapper.IMapper;
using Online_Learning_Platform.Mappers.UIMapper.Model;

namespace Online_Learning_Platform.Mappers.UIMapper.Mapper
{
    public class RegistrationMapper : IRegistrationMapper
    {
        public Registration Map(RegistrationDto registrationDto)
        {
            var registration = new Registration();
            registration.Id = registrationDto.Id;
            registration.Name = registrationDto.Name;
            registration.Email = registrationDto.Email;
            registration.Password = registrationDto.Password;
            return registration;
        }

        public List<Registration> Map(List<RegistrationDto> registrationDto)
        {
            var registrationDtoS = new List<Registration>();
            foreach (var dto in registrationDto)
            {
                var registrationItem = new Registration
                {
                    Id = dto.Id,
                    Name = dto.Name,
                    Email = dto.Email,
                    Password = dto.Password
                };

                registrationDtoS.Add(registrationItem);
            }
            return registrationDtoS;
        }
    }
  
}
