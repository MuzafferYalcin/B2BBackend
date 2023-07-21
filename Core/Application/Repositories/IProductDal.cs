using Domain.DTOs;
using Domain.Entities;

namespace Application.Repositories
{
    public interface IProductDal : IRepository<Product>
    {
        public List<ProductforCustomerDto> GetListForCustomer(int customerId);
        public ProductforCustomerDto GetForCustomer(int id,int customerId);
    }
}
