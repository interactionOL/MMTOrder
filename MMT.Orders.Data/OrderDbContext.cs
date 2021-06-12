using Microsoft.EntityFrameworkCore;
using MMT.Orders.Business;

namespace MMT.Orders.Data
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext( DbContextOptions<OrderDbContext> options ) : base( options )
        {

        }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Product> Products { get; set; }


        protected override void OnModelCreating( ModelBuilder modelBuilder )
        {
            modelBuilder.Entity<Order>()
                .HasMany( o => o.OrderItems )
                .WithOne( oi => oi.Order )
                .OnDelete( DeleteBehavior.Cascade );
            //modelBuilder.Entity<Product>();

            modelBuilder.Entity<OrderItem>()
                .ToTable( "OrderItems" );
        }
    }
}
