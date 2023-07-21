using Application.Abstractions;
using Application.Repositories;
using Application.Results.Abstract;
using Application.Results.Concrete;
using Domain.DTOs;
using Domain.Entities;

namespace Persistence.Services
{
    public class BasketService : IBasketService
    {
        private readonly IBasketDal _basketDal;

        public BasketService(IBasketDal basketDal)
        {
            _basketDal = basketDal;
        }

        public IResult Add(Basket basket)
        {
            _basketDal.Add(basket);
            return new SuccessResult("Başarıyla eklendi");
        }

        public IResult Delete(Basket basket)
        {
            _basketDal.Delete(basket);
            return new SuccessResult("Başarıyla silindi");
        }

        public IDataResult<Basket> Get(int id)
        {
            return new SuccessDataResult<Basket>(_basketDal.Get(p => p.Id == id));
        }

        public IDataResult<List<BasketDto>> GetByCustomerId(int CustomerId)
        {
            return new SuccessDataResult<List<BasketDto>>(_basketDal.GetByCustomerId(CustomerId));
        }

        public IDataResult<List<Basket>> GetList()
        {
            return new SuccessDataResult<List<Basket>>(_basketDal.GetList());
        }

        public IResult Update(Basket basket)
        {
            _basketDal.Update(basket);
            return new SuccessResult("Başarıyla güncellendi");
        }
    }
}
