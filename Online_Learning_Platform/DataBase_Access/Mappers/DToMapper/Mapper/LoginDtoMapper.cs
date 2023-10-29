using DataBase_Access.Mappers.DToMapper.IMapper;
using DataBase_Access.Mappers.DToMapper.Model;
using DataBase_Access.Mappers.UIMapper.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase_Access.Mappers.DToMapper.Mapper
{
    public class LoginDtoMapper : ILoginDtoMapper
    {
        public LoginDto Map(Login login)
        {
            var loginDto = new LoginDto();
            loginDto.Email = login.Email;
            loginDto.Password = login.Password;
            return loginDto;
        }
    }
}
