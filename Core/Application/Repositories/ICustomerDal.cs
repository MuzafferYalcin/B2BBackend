using Domain.DTOs;
using Domain.Entities;

namespace Application.Repositories
{
    public interface ICustomerDal : IRepository<Customer>
    {
        public List<CustomerDto> GetWithDiscount();
    }
}
