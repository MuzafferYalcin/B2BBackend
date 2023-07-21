using Application.Results.Abstract;
using Domain.DTOs;
using Domain.Entities;

namespace Application.Abstractions
{
    public interface IOrderItemService
    {
        public IResult Add(OrderItem orderItem);
        public IResult Update(OrderItem orderItem);
        public IResult Delete(OrderItem orderItem);
        public IDataResult<List<OrderItem>> GetList();
        public IDataResult<List<OrderItem>> GetListByOrderId(int orderId);
        public IDataResult<List<OrderItemsDto>> GetListDto(int orderId);
    }
}
