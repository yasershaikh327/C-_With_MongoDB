using DataBase_Access.Mappers.UIMapper.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase_Access.Mappers.UIMapper.IMapper
{
    public interface IContactMapper
    {
        Contact Map(ContactDto contactDto);
        List<Contact> Map(List<ContactDto> contactDto);
    }
}
