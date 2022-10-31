namespace Cryptocop.Software.API.Repositories.Entities
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        // Navigation properties
        public User User { get; set; }
    }
}