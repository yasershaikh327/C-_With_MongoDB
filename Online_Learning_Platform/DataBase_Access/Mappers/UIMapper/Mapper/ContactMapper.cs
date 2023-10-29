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
    public class ContactMapper : IContactMapper
    {
        public Contact Map(ContactDto contactDto)
        {
            var contact = new Contact();    
            contact.Id = contactDto.Id;
            contact.Fullname = contactDto.Fullname;
            contact.Email = contactDto.Email;
            contact.Message = contactDto.Message;   
            return contact;
        }

        public List<Contact> Map(List<ContactDto> contactDto)
        {
            var contactDtos = new List<Contact>();
            foreach (var dto in contactDto)
            {
                var contactItem = new Contact
                {
                    Id = dto.Id,
                    Fullname = dto.Fullname,
                    Email = dto.Email,
                   Message = dto.Message
                };

                contactDtos.Add(contactItem);
            }
            return contactDtos;
        }
    }
}
