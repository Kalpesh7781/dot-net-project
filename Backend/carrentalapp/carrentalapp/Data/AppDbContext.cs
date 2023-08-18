using carrentalapp.Model;
using Microsoft.EntityFrameworkCore;

namespace carrentalapp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }
        public DbSet<Booking> Bookings { get; set; }



        public DbSet<Car> Cars { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<Cancel> Cancels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>()
                .HasOne(c => c.car)
                .WithMany(p => p.Bookings)
                .HasForeignKey(c => c.car_id);


            modelBuilder.Entity<Booking>()
                .HasOne(u => u.user)
                .WithMany(b => b.Bookings)
                .HasForeignKey(k => k.user_no);



            base.OnModelCreating(modelBuilder);
        }



    }
}
