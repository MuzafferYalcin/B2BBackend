using Domain.DTOs;
using Domain.Entities;

namespace Application.Repositories
{
    public interface IBasketDal : IRepository<Basket>
    {
        public List<BasketDto> GetByCustomerId(int customerId);
    }
}
