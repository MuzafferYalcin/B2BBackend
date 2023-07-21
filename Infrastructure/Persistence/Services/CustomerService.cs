using Application.Abstractions;
using Application.Repositories;
using Application.Results.Abstract;
using Application.Results.Concrete;
using Application.Utilities.Hashing;
using Domain.DTOs;
using Domain.Entities;

namespace Persistence.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerDal _customerDal;
        private readonly IBasketService _basketService;
        private readonly IOrderService _orderService;
        private readonly ICustomerDiscountService _customerDiscountService;

        public CustomerService(ICustomerDal customerDal, IBasketService basketService, IOrderService orderService, ICustomerDiscountService customerDiscountService)
        {
            _customerDal = customerDal;
            _basketService = basketService;
            _orderService = orderService;
            _customerDiscountService = customerDiscountService;
        }

        public IResult Add(RegisterDto register)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(register.Password, out passwordHash, out passwordSalt);
            Customer customer = new Customer()
            {
                Name = register.Name,
                Email = register.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };
            _customerDal.Add(customer);
            return new SuccessResult("Başarıyla eklendi");
        }

        public IResult Delete(int id)
        {
            var customer = _customerDal.Get(p => p.Id == id);
            var orders = _orderService.GetByCustomerId(customer.Id).Data;
            foreach (var order in orders)
            {
                _orderService.Delete(order);
            }
            var sepets = _basketService.GetByCustomerId(customer.Id).Data;
            foreach (var sepet in sepets)
            {
                _basketService.Delete(sepet);
            }
            var discount = _customerDiscountService.GetByCustomerId(customer.Id).Data;
            if (discount != null)
            {
                _customerDiscountService.Delete(discount);
             }

            _customerDal.Delete(customer);
            return new SuccessResult("Başarıyla Silindi");
        }

        public IDataResult<Customer> Get(int id)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(p => p.Id == id));
        }

        public IDataResult<List<Customer>> GetList()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetList());
        }

        public IDataResult<List<CustomerDto>> GetWithDiscount()
        {
            return new SuccessDataResult<List<CustomerDto>>(_customerDal.GetWithDiscount());
        }

        public IResult Update(Customer customer)
        {
            _customerDal.Update(customer);
            return new SuccessResult("Başarıyla Güncellendi");
        }
    }
}
