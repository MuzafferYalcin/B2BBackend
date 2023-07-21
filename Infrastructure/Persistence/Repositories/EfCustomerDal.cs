using Application.Repositories;
using Domain.DTOs;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class EfCustomerDal : RepositoryBase<Customer, ContextDb>, ICustomerDal
    {
        public List<CustomerDto> GetWithDiscount()
        {
            using (var context = new ContextDb())
            {
                var result = from customer in context.Customers
                             select new CustomerDto
                             {
                                 Discount = (context.CustomerDiscounts.Where(p=>p.CustomerId == customer.Id) == null) ? 0 : context.CustomerDiscounts.Where(p => p.CustomerId == customer.Id).Select(p=>p.Discount).FirstOrDefault(),
                                 Id = customer.Id,
                                 Email= customer.Email,
                                 Name = customer.Name, 
                             };
                return result.OrderBy(x => x.Name).ToList();
            }
        }
    }
}
