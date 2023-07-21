using Domain.Entities;

namespace Domain.DTOs
{
    public class CustomerDto : Customer
    {
        public int Discount { get; set; }
    }
}
