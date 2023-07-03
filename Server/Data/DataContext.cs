using EPS_task.Shared;
using Microsoft.EntityFrameworkCore;

namespace EPS_task.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DiscountCode>().HasData(
                new DiscountCode { Id = 1, Code = "asdfg145", CreatedOn = DateTime.Now },
                new DiscountCode { Id = 2, Code = "kjgh45r8", CreatedOn = DateTime.Now }
            );
        }

        public DbSet<DiscountCode> DiscountCodes { get; set; }
    }
}
