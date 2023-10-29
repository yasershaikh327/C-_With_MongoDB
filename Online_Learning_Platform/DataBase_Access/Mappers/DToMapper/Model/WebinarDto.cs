using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase_Access.Mappers.DToMapper.Model
{
    public class WebinarDto
    {
        public int Id { get; set; }
        public string WebinarName { get; set; }
        public string WebinarDescription { get; set; }
    }

    public class WebinarDtos
    {
        public WebinarDto WebinarDto { get; set; }
        public WebinarDtos() { 
            WebinarDto = new WebinarDto();
        }
    }
}
