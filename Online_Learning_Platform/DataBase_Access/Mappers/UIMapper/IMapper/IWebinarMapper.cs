using DataBase_Access.Mappers.DToMapper.Model;
using DataBase_Access.Mappers.UIMapper.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase_Access.Mappers.UIMapper.IMapper
{
    public interface IWebinarMapper
    {
        Webinar Map(WebinarDto webinarDto);
        List<Webinar> Map(List<WebinarDto> webinarDto);
    }
}
