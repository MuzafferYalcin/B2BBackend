using Domain.DTOs;
using Domain.Entities;

namespace Application.Repositories
{
    public interface IOrderItemDal : IRepository<OrderItem> 
    {
        public List<OrderItemsDto> GetListDto(int orderId);
    }
}
