using Microsoft.EntityFrameworkCore;
using Rentify.Services.Database;

public static class SeedData
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Role>().HasData(
        new Role
        {
            Id = 1,
            Name = "Korisnik",
            Description = "Standardni korisnik aplikacije",
            IsActive = true,
            CreatedAt = DateTime.UtcNow
        },
        new Role
        {
            Id = 2,
            Name = "Vlasnik",
            Description = "Vlasnik nekretnina koji može upravljati objektima",
            IsActive = true,
            CreatedAt = DateTime.UtcNow
        }
        );
    }
}