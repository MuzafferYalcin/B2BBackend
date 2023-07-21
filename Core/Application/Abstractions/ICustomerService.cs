using Application.Results.Abstract;
using Domain.DTOs;
using Domain.Entities;

namespace Application.Abstractions
{
    public interface ICustomerService
    {
        public IResult Add(RegisterDto register);
        public IResult Update(Customer customer);
        public IDataResult<List<CustomerDto>> GetWithDiscount();
        public IResult Delete(int id);
        public IDataResult<Customer> Get(int id);
        public IDataResult<List<Customer>> GetList();
    }
}
