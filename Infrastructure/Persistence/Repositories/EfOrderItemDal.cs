using Application.Repositories;
using Domain.DTOs;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class EfOrderItemDal : RepositoryBase<OrderItem, ContextDb>, IOrderItemDal
    {
        public List<OrderItemsDto> GetListDto(int orderId)
        {
            using (var context = new ContextDb())
            {
                var results = from orderitem in context.OrderItems.Where(p => p.OrderId == orderId)
                             join product in context.Products on orderitem.ProductId equals product.Id
                             select new OrderItemsDto
                             {
                                 Id = orderitem.Id,
                                 OrderId = orderitem.OrderId,
                                 ProductId = product.Id,
                                 Quantity = orderitem.Quantity,
                                 ProductName = product.Name,
                                 Price = orderitem.Price,
                                 Total = orderitem.Quantity * orderitem.Price,
                             };

                return  results.ToList();
            }
        }
    }
}
