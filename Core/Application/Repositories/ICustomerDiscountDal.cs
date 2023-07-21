using Domain.Entities;

namespace Application.Repositories
{
    public interface ICustomerDiscountDal : IRepository<CustomerDiscount>
    {
        public CustomerDiscount GetByCustomerId(int customerId);
    }
}
