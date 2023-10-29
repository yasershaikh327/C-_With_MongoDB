using DataBase_Access.Mappers.DToMapper.IMapper;
using DataBase_Access.Mappers.UIMapper.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase_Access.Mappers.DToMapper.Mapper
{
    public class ContactDtoMapper : IContactDtoMapper
    {
        public ContactDto Map(Contact contact)
        {
            var contactDtos = new ContactDto();
            contactDtos.Id = contact.Id;
            contactDtos.Fullname = contact.Fullname;
            contactDtos.Email = contact.Email;
            contactDtos.Message = contact.Message;   
            return contactDtos;
        }
    }
}
