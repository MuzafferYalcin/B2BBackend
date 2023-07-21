using Application.Results.Abstract;
using Domain.DTOs;
using Domain.Entities;

namespace Application.Abstractions
{
    public interface IProductService
    {
        public IResult Add(Product product);
        public IResult Delete(Product product);
        public IResult Update(Product product);
        public IDataResult<Product> Get(int id);
        public IDataResult<List<Product>> GetList();
        public IDataResult<List<ProductforCustomerDto>> GetListforCustomer(int customerId);
        public IDataResult<ProductforCustomerDto> GetforCustomer(int id, int customerId);

    }
}
