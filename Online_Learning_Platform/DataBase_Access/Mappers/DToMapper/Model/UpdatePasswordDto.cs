using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase_Access.Mappers.DToMapper.Model
{
    public class UpdatePasswordDto
    {
        public int Id { get; set; }
        public string oldPassword { get; set; }
        public string Password { get; set; }
    }

    public class UpdatePasswordDtos
    {
        UpdatePasswordDto UpdatePasswordDto { get; set; }
        public UpdatePasswordDtos() { 
            UpdatePasswordDto = new UpdatePasswordDto();
        }
    }
}
