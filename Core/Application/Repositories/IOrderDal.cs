using Domain.DTOs;
using Domain.Entities;

namespace Application.Repositories
{
    public interface IOrderDal : IRepository<Order>
    {
        public List<OrderDto> GetOrderListDto();
        public OrderDto GetOrderDto(int id);
        public List<OrderDto> GetListByCustomer(int customerid);
        public string GetOrderNumber();
    }
}
