namespace Cryptocop.Software.API.Repositories.Entities
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string ProductIdentifier { get; set; }
        public float Quantity { get; set; }
        public float UnitPrice { get; set; }
        public float TotalPrice { get; set; }

        // Navigation properties
        public Order Order { get; set; }
    }
}