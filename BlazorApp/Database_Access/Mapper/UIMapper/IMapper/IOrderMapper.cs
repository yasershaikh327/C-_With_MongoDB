using Database_Access.Mapper.UIMapper.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database_Access.Mapper.UIMapper.IMapper
{
    public interface IOrderMapper
    {
        Order Map(OrderDto orderDto);
        List<Order> Map(List<OrderDto> orderDto);
    }
}
