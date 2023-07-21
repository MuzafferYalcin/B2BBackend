using Domain.Entities;

namespace Domain.DTOs
{
    public class OrderDto : Order
    {
        public string CustomerName { get; set; }
        public decimal TotalPrice { get; set; }
        
    }
}
