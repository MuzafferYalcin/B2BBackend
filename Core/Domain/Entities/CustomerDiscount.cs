namespace Domain.Entities
{
    public class CustomerDiscount
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int Discount { get; set; }
    }
}
