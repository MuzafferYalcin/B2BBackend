using Application.Abstractions;
using Application.Repositories;
using Application.Results.Abstract;
using Application.Results.Concrete;
using Domain.Entities;

namespace Persistence.Services
{
    public class CustomerDiscountService : ICustomerDiscountService
    {
        private readonly ICustomerDiscountDal _customerDiscountDal;

        public CustomerDiscountService(ICustomerDiscountDal customerDiscountDal)
        {
            _customerDiscountDal = customerDiscountDal;
        }

        public IResult Add(CustomerDiscount customerDiscount)
        {
            _customerDiscountDal.Add(customerDiscount);
            return new SuccessResult("başarıyla Eklendi");
        }

        public IResult Delete(CustomerDiscount customerDiscount)
        {
            _customerDiscountDal.Delete(customerDiscount);
            return new SuccessResult("başarıyla Silindi");
        }

        public IDataResult<CustomerDiscount> GetByCustomerId(int customerId)
        {
            return new SuccessDataResult<CustomerDiscount>(_customerDiscountDal.GetByCustomerId(customerId));
        }

        public IDataResult<CustomerDiscount> GetById(int id)
        {
          return new SuccessDataResult<CustomerDiscount>(_customerDiscountDal.Get(p=> p.Id == id));
        }

        public IDataResult<List<CustomerDiscount>> GetList()
        {
            return new SuccessDataResult<List<CustomerDiscount>>(_customerDiscountDal.GetList());
        }

        public IResult Update(CustomerDiscount customerDiscount)
        {
            _customerDiscountDal.Update(customerDiscount);
            return new SuccessResult("başarıyla Güncellendi");
        }
    }
}
