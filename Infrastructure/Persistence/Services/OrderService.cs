using Application.Abstractions;
using Application.Repositories;
using Application.Results.Abstract;
using Application.Results.Concrete;
using Domain.DTOs;
using Domain.Entities;

namespace Persistence.Services
{
    public class OrderService : IOrderService
    {
        private readonly IBasketService _basketService;
        private readonly IOrderDal _orderDal;
        private readonly IOrderItemService _orderItemService;
        public OrderService(IBasketService basketService, IOrderDal orderDal, IOrderItemService orderItemService)
        {
            _basketService = basketService;
            _orderDal = orderDal;
            _orderItemService = orderItemService;
        }
        
        
        public IDataResult<Order> GetById(int id)
        {
            return new SuccessDataResult<Order>(_orderDal.Get(p => p.Id == id));
        }

        public IResult Add(int customerId)
        {
            var baskets = _basketService.GetByCustomerId(customerId);
            string newOrderNumber = _orderDal.GetOrderNumber();
            Order order = new()
            {
                CustomerId = customerId,
                Date = DateTime.Now,
                OrderNumber = newOrderNumber,
                State = "Onay Bekliyor"
            };
            _orderDal.Add(order);
            foreach (var basket in baskets.Data)
            {
                OrderItem orderItem = new()
                {
                    OrderId = order.Id,
                    ProductId = basket.ProductId,
                    Quantity = basket.Quantity,
                    Price = basket.Fiyat,
                };
                _orderItemService.Add(orderItem);
                _basketService.Delete(basket);
            }

            return new SuccessResult("Sipariş Eklendi");
        }

        public IResult Delete(Order order)
        {
            var orderItems = _orderItemService.GetListByOrderId(order.Id);
            foreach (var orderItem in orderItems.Data)
            {
                _orderItemService.Delete(orderItem);
            }
            _orderDal.Delete(order);
            return new SuccessResult("Silindi");
        }

        public IDataResult<List<OrderDto>> GetAll()
        {
            return new SuccessDataResult<List<OrderDto>>(_orderDal.GetOrderListDto());
        }

        public IDataResult<List<OrderDto>> GetListByCustomerId(int customerId)
        {
            return new SuccessDataResult<List<OrderDto>>(_orderDal.GetListByCustomer(customerId));
        }

        public IResult Update(Order order)
        {
            _orderDal.Update(order);
            return new SuccessResult("güncellendi");
        }

        public IDataResult<OrderDto> GetByIdDto(int id) { 
            return new SuccessDataResult<OrderDto>(_orderDal.GetOrderDto(id));
        }
    }
}
