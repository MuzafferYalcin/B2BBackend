using Application.Repositories;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class EfCustomerDiscountDal : RepositoryBase<CustomerDiscount, ContextDb>, ICustomerDiscountDal
    {
        public CustomerDiscount GetByCustomerId(int customerId)
        {
            using(var context = new ContextDb())
            {
                var result = context.CustomerDiscounts.FirstOrDefault(p => p.CustomerId == customerId);
                return result;
            }
        }
    }
}
