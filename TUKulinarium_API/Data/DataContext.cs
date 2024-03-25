
using Microsoft.EntityFrameworkCore;

namespace IllegalLibAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        { }
        // public DbSet<User> Users { get; set; }
        // public DbSet<AuthUser> AuthUsers { get; set; }
        // public DbSet<Book> Books { get; set; }
        // public DbSet<BookFile> BookFiles { get; set; }
        // public DbSet<Author> Authors { get; set; }
        // public DbSet<Publisher> Publishers { get; set; }
        // public DbSet<BookRequest> BookRequests { get; set; }

        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     modelBuilder.Entity<User>()
        //         .HasOne(u => u.AuthUser)
        //         .WithOne()
        //         .HasForeignKey<AuthUser>(au => au.UserId)
        //         .OnDelete(DeleteBehavior.Cascade);
        // }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
    }
}