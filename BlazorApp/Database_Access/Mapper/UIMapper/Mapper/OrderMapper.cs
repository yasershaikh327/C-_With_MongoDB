using Database_Access.Mapper.UIMapper.IMapper;
using Database_Access.Mapper.UIMapper.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database_Access.Mapper.UIMapper.Mapper
{
    public class OrderMapper : IOrderMapper
    {
        public Order Map(OrderDto orderDto)
        {
            var order = new Order();
            order.Id = orderDto.Id;
            order.Customer_Id = orderDto.Customer_Id;
            order.ItemPrice = orderDto.ItemPrice;
            order.ItemName = orderDto.ItemName;
            return order;
        }

        public List<Order> Map(List<OrderDto> orderDto)
        {
            var list = new List<Order>();
            foreach (var item in orderDto)
            {
                var order = new Order()
                {
                    Customer_Id = item.Customer_Id,
                    Id = item.Id,
                    ItemName = item.ItemName,
                    ItemPrice = item.ItemPrice
                };
                list.Add(order);
            }
            return list;
        }
    }
}
