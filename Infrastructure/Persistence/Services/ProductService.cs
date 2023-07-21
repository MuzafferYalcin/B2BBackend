using Application.Abstractions;
using Application.Repositories;
using Application.Results.Abstract;
using Application.Results.Concrete;
using Domain.DTOs;
using Domain.Entities;

namespace Persistence.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductDal _productDal;

        public ProductService(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public IResult Add(Product product)
        {
            _productDal.Add(product);
            return new SuccessResult("Ürün Başarıyla Eklendi");
        }

        public IResult Delete(Product product)
        {
            _productDal.Delete(product);
            return new SuccessResult("Ürün Başarıyla Silindi");
        }

        public IDataResult<Product> Get(int id)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.Id == id));
        }

        public IDataResult<List<ProductforCustomerDto>> GetListforCustomer(int customerId)
        {
            return new SuccessDataResult<List<ProductforCustomerDto>>(_productDal.GetListForCustomer(customerId));
        }

        public IDataResult<List<Product>> GetList()
        {
            var products = _productDal.GetList().OrderBy(p=>p.Name).ToList();
            return new SuccessDataResult<List<Product>>(products);
        }

        public IResult Update(Product product)
        {
            _productDal.Update(product);
            return new SuccessResult("Ürün Başarıyla Güncellendi");
        }

        public IDataResult<ProductforCustomerDto> GetforCustomer(int id, int customerId)
        {
            return new SuccessDataResult<ProductforCustomerDto>(_productDal.GetForCustomer(id, customerId));
        }
    }
}
