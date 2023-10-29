using API.Mapper.DtoMapper.Model;
using API.Mapper.UIMapper.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database_Access.Mapper.UIMapper.Model
{
    public class Order
    {
        public int Id { get; set; }
        public string Customer_Id { get; set; }
        public string ItemName { get; set; }
        public double ItemPrice { get; set; }


    }
}
