using Domain.Entities;

namespace Domain.DTOs
{
    public class ProductforCustomerDto : Product
    {
        public int Discount { get; set; }
    }
}
