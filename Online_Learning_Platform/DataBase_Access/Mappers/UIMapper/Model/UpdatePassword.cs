using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase_Access.Mappers.UIMapper.Model
{
    public class UpdatePassword
    {
        public int Id { get; set; }
        public string oldPassword { get; set; }
        public string Password { get; set; }
    }
}
