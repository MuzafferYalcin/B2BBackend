using Domain.Entities;

namespace Domain.DTOs
{
    public class BasketDto : Basket
    {
        public decimal Total { get; set; }
        public string ProductName { get; set; }
    }
}
