using DataBase_Access.Mappers.DToMapper.Model;
using DataBase_Access.Mappers.UIMapper.IMapper;
using DataBase_Access.Mappers.UIMapper.Model;
using Online_Learning_Platform.Mappers.UIMapper.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase_Access.Mappers.UIMapper.Mapper
{
    public class WebinarMapper : IWebinarMapper
    {
        public Webinar Map(WebinarDto webinarDto)
        {
            var mapper = new Webinar();
            mapper.Id = webinarDto.Id;
            mapper.WebinarName = webinarDto.WebinarName;
            mapper.WebinarDescription = webinarDto.WebinarDescription;
            return mapper;
        }

        public List<Webinar> Map(List<WebinarDto> webinarDto)
        {
            var webinarDtoS = new List<Webinar>();
            foreach (var dto in webinarDto)
            {
                var webinarItem = new Webinar
                {
                    Id = dto.Id,
                    WebinarDescription = dto.WebinarDescription,    
                    WebinarName = dto.WebinarName,  
                };

                webinarDtoS.Add(webinarItem);
            }
            return webinarDtoS;
        }
    }
}
