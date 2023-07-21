using Application.Results.Abstract;
using Domain.DTOs;
using Domain.Entities;

namespace Application.Abstractions
{
    public interface IBasketService
    {
        public IResult Add(Basket basket);
        public IResult Delete(Basket basket);
        public IResult Update(Basket basket);
        public IDataResult<Basket> Get(int id);
        public IDataResult<List<BasketDto>> GetByCustomerId(int CustomerId);
        public IDataResult<List<Basket>> GetList();
    }
}
