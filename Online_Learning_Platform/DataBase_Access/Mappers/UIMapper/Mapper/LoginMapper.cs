using DataBase_Access.Mappers.DToMapper.Model;
using DataBase_Access.Mappers.UIMapper.IMapper;
using DataBase_Access.Mappers.UIMapper.Model;


namespace DataBase_Access.Mappers.UIMapper.Mapper
{
    public class LoginMapper : ILoginMapper
    {
        public Login Map(LoginDto loginDto)
        {
            var Login = new Login();
            Login.Email = loginDto.Email;
            Login.Password = loginDto.Password;
            return Login;
        }
    }
}
