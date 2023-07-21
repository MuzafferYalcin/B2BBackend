namespace Domain.Entities
{
    public class Basket
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Fiyat { get; set; }
    }
}
