
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TUKulinarium_API.Data.Models;

namespace TUKulinarium_API.Data
{
    public class DataContext : IdentityDbContext<User>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Burger> Burgers { get; set; }
        public DbSet<Side> Sides { get; set; }
        public DbSet<Drink> Drinks { get; set; }
        public DbSet<Dessert> Desserts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<PaymentInfo> Payments { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
            .HasOne<UserProfile>(u => u.UserProfile)
            .WithOne(p => p.User)
            .HasForeignKey<UserProfile>(p => p.UserId);

            modelBuilder.Entity<UserProfile>()
                .HasMany(p => p.Orders)
                .WithOne(p => p.UserProfile)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Pizza>()
                .Property(z => z.DishPrice)
                .HasPrecision(5, 2);
            modelBuilder.Entity<Burger>()
                .Property(b => b.DishPrice)
                .HasPrecision(4, 2);
            modelBuilder.Entity<Drink>()
                .Property(d => d.DishPrice)
                .HasPrecision(4, 2);
            modelBuilder.Entity<Side>()
                .Property(s => s.DishPrice)
                .HasPrecision(4, 2);
            modelBuilder.Entity<Dessert>()
                .Property(t => t.DishPrice)
                .HasPrecision(4, 2);
            modelBuilder.Entity<Salad>()
                .Property(l => l.DishPrice)
                .HasPrecision(4, 2);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
    }
}