using Microsoft.EntityFrameworkCore;
using Cryptocop.Software.API.Repositories.Entities;

namespace Cryptocop.Software.API.Repositories.Contexts
{
    public class CryptocopDbContext : DbContext
    {
        public CryptocopDbContext(DbContextOptions options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>()
                .HasKey(x => new { x.Id, x.UserId });
            modelBuilder.Entity<JwtToken>()
                .HasKey(x => new { x.Id });
            modelBuilder.Entity<Order>()
                .HasKey(x => new { x.Id });
            modelBuilder.Entity<OrderItem>()
                .HasKey(x => new { x.Id, x.OrderId });
            modelBuilder.Entity<PaymentCard>()
                .HasKey(x => new { x.Id, x.UserId });
            modelBuilder.Entity<ShoppingCart>()
                .HasKey(x => new { x.Id, x.UserId });
            modelBuilder.Entity<ShoppingCartItem>()
                .HasKey(x => new { x.Id, x.ShoppingCartID });
            modelBuilder.Entity<User>()
                .HasKey(x => new { x.Id });
        }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<JwtToken> JwtTokens { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<PaymentCard> PaymentCards { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<User> Users { get; set; }
    }
}