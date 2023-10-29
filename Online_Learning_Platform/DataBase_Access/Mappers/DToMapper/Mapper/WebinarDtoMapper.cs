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
    public class WebinarDtoMapper : IWebinarDtoMapper
    {
        public WebinarDto Map(Webinar webinar)
        {
            var mapper = new WebinarDto();
            mapper.Id = webinar.Id;
            mapper.WebinarName = webinar.WebinarName;
            mapper.WebinarDescription = webinar.WebinarDescription; 
            return mapper;
        }
    }
}
