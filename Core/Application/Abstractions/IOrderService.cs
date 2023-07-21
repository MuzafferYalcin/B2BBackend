using Application.Results.Abstract;
using Domain.DTOs;
using Domain.Entities;

namespace Application.Abstractions
{
    public interface IOrderService
    {
        public IDataResult<Order> GetById(int id);
        public IResult Add(int customerId);
        public IResult Update(Order order);
        public IResult Delete(Order order);
        public IDataResult<List<OrderDto>> GetAll();
        public IDataResult<List<Order>> GetByCustomerId(int customerId);
        public IDataResult<OrderDto> GetByIdDto(int id);

    }
}
