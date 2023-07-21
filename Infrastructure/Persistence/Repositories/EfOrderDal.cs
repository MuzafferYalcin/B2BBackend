using Application.Repositories;
using Domain.DTOs;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Persistence.Services;
using System.Security.Cryptography;

namespace Persistence.Repositories
{
    public class EfOrderDal : RepositoryBase<Order, ContextDb>, IOrderDal
    {
        public List<OrderDto> GetOrderListDto()
        {
            using (var context = new ContextDb())
            {
                var orders = (from order in context.Orders
                             join customer in context.Customers on order.CustomerId equals customer.Id
                             select new OrderDto
                             {
                                 Id = order.Id,
                                 CustomerId = customer.Id,
                                 CustomerName = customer.Name,
                                 Date = order.Date,
                                 OrderNumber = order.OrderNumber,
                                 State = order.State,
                                 TotalPrice = context.OrderItems.Distinct().Where(p=> p.OrderId == order.Id).Sum(p=> p.Quantity *  p.Price)
                             });
                return orders.OrderByDescending(p=>p.Date).ToList();
            }
        }

        public OrderDto GetOrderDto(int id)
        {
            using (var context = new ContextDb())
            {
                var orders = from order in context.Orders.Where(p=> p.Id == id)
                              join customer in context.Customers on order.CustomerId equals customer.Id
                              select new OrderDto
                              {
                                  Id = order.Id,
                                  CustomerId = customer.Id,
                                  CustomerName = customer.Name,
                                  Date = order.Date,
                                  OrderNumber = order.OrderNumber,
                                  State = order.State,
                                  TotalPrice = context.OrderItems.Distinct().Where(p => p.OrderId == order.Id).Sum(p => p.Quantity * p.Price)
                              };
                return orders.FirstOrDefault();
            }
        }

        public string GetOrderNumber()
        {
            using (var context = new ContextDb())
            {
                var findLastOrder = context.Orders.OrderBy(p => p.Id).LastOrDefault();

                if (findLastOrder == null)
                {
                    return "SP00000000000001";
                }

                string findLastOrderNumber = findLastOrder.OrderNumber;
                findLastOrderNumber = findLastOrderNumber.Substring(2, 14);
                int orderNumberInt = Convert.ToInt16(findLastOrderNumber);
                orderNumberInt++;
                string newOrderNumber = orderNumberInt.ToString();

                for (int i = newOrderNumber.Length; i < 14; i++)
                {
                    newOrderNumber = "0" + newOrderNumber;
                }

                newOrderNumber = "SP" + newOrderNumber;
                return newOrderNumber;
            }
        }
    }
}
