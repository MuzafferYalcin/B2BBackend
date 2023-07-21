using Application.Repositories;
using Domain.DTOs;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class EfProductDal : RepositoryBase<Product, ContextDb>, IProductDal
    {
        public ProductforCustomerDto GetForCustomer(int id,int customerId)
        {
            using( var  context = new ContextDb() )
            {
                var result = from product in context.Products.Where(p=>p.Id == id)
                             select new ProductforCustomerDto
                             {
                                 Name = product.Name,
                                 Price = product.Price,
                                 Id = product.Id,
                                 Discount = context.CustomerDiscounts.Where(p => p.CustomerId == customerId).Select(p => p.Discount).FirstOrDefault(),
                             };
                return result.FirstOrDefault();
            }
            
        }

        public List<ProductforCustomerDto> GetListForCustomer(int customerId)
        {
            using (var context = new ContextDb())
            {
                var result = from product in context.Products
                             select new ProductforCustomerDto
                             {
                                 Name = product.Name,
                                 Price = product.Price,
                                 Id = product.Id,
                                 Discount = context.CustomerDiscounts.Where(p=>p.CustomerId ==customerId).Select(p=>p.Discount).FirstOrDefault(),
                             };
                return result.ToList();
            }
        }
    }
}