using Application.Abstractions;
using Application.Repositories;
using Application.Results.Abstract;
using Application.Results.Concrete;
using Domain.DTOs;
using Domain.Entities;
using Persistence.Repositories;

namespace Persistence.Services
{
    public class OrderItemManager : IOrderItemService
    {
        private readonly IOrderItemDal _orderItemDal;

        public OrderItemManager(IOrderItemDal orderItemDal)
        {
            _orderItemDal = orderItemDal;
        }

        public IResult Add(OrderItem orderItem)
        {
            _orderItemDal.Add(orderItem);
            return new SuccessResult("eklendi");
        }

        public IResult Delete(OrderItem orderItem)
        {
            _orderItemDal.Delete(orderItem);
            return new SuccessResult("silindi");
        }

        public IDataResult<List<OrderItem>> GetList()
        {
            return new SuccessDataResult<List<OrderItem>>(_orderItemDal.GetList());
        }

        public IDataResult<List<OrderItem>> GetListByOrderId(int orderId)
        {
            return new SuccessDataResult<List<OrderItem>>(_orderItemDal.GetList(p=>p.OrderId == orderId));
        }

        public IDataResult<List<OrderItemsDto>> GetListDto(int orderId)
        {
            return new SuccessDataResult<List<OrderItemsDto>>(_orderItemDal.GetListDto(orderId));
        }

        public IResult Update(OrderItem orderItem)
        {
            _orderItemDal.Update(orderItem);
            return new SuccessResult("güncellendi");
        }
    }
}
