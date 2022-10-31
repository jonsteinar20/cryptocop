namespace Cryptocop.Software.API.Repositories.Entities
{
    public class ShoppingCartItem
    {
        public int Id { get; set; }                     // PK
        public int ShoppingCartID { get; set; }         // FK
        public string ProductIdentifier { get; set; }
        public float Quantity { get; set; }
        public float UnitPrice { get; set; }

        // Navigation properties
        public ShoppingCart ShoppingCart { get; set; }
    }
}