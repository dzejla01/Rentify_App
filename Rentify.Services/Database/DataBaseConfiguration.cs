using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace eTravelAgencija.Services.Database
{
    public class RentifyDbContextFactory : IDesignTimeDbContextFactory<RentifyDbContext>
    {
        public RentifyDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<RentifyDbContext>();
            optionsBuilder.UseNpgsql("Host=localhost;Database=RentifyDB;Username=postgres;Password=1234");

            return new RentifyDbContext(optionsBuilder.Options);
        }
    }
}
