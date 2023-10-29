using Database_Access.Mapper.UIMapper.IMapper;
using Database_Access.Mapper.UIMapper.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database_Access.Mapper.UIMapper.Mapper
{
    public class OrderDtoMapper : IOrderDtoMapper
    {
        public OrderDto Map(Order order)
        {
            var orderDto = new OrderDto();
            orderDto.Id = order.Id;
            orderDto.ItemPrice = order.ItemPrice;
            orderDto.ItemName = order.ItemName;
            orderDto.Customer_Id = order.Customer_Id;
            return orderDto;
        }
    }
}
