using DataBase_Access.Mappers.DToMapper.Model;
using DataBase_Access.Mappers.UIMapper.Model;


namespace DataBase_Access.Mappers.UIMapper.IMapper
{
    public interface ILoginMapper
    {
        Login Map(LoginDto loginDto);
    }

}
