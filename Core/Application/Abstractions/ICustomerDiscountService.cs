using Application.Results.Abstract;
using Domain.Entities;

namespace Application.Abstractions
{
    public interface ICustomerDiscountService
    {
        public IResult Add(CustomerDiscount customerDiscount);
        public IResult Update(CustomerDiscount customerDiscount);
        public IResult Delete(CustomerDiscount customerDiscount);
        public IDataResult<CustomerDiscount>GetById(int id);
        public IDataResult<List<CustomerDiscount>> GetList();
        public IDataResult<CustomerDiscount> GetByCustomerId(int customerId);
    }
}
