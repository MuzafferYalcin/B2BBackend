using Application.Repositories;
using Domain.DTOs;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class EfBasketDal : RepositoryBase<Basket, ContextDb>, IBasketDal
    {
        public List<BasketDto> GetByCustomerId(int customerId)
        {
            using (var context = new ContextDb())
            {
                var baskets = from basket in context.Baskets
                              where basket.CustomerId == customerId
                              join product in context.Products on basket.ProductId equals product.Id
                              select new BasketDto
                              {
                                  Id = basket.Id,
                                  CustomerId = customerId,
                                  Fiyat = basket.Fiyat,
                                  ProductId = basket.ProductId,
                                  ProductName = product.Name,
                                  Quantity = basket.Quantity,
                                  Total = basket.Fiyat* basket.Quantity
                              };
                return baskets.ToList();
            }
        }
    }
}
