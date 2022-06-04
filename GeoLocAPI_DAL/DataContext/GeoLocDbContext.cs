using GeoLocAPI_Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace GeoLocAPI_DAL.DataContext
{
    public class GeoLocDbContext : DbContext
    {
        public GeoLocDbContext(DbContextOptions<GeoLocDbContext> options) : base(options)
        {
        }

        public DbSet<LoginModel>? LoginModels { get; set; }
        public DbSet<GeoLocationData>? GeoLocations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LoginModel>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<GeoLocationData>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<LoginModel>()
                .HasData(new LoginModel[]
                {
                        new LoginModel() { Id = Guid.NewGuid(), Username = "admin", Password = BCrypt.Net.BCrypt.HashPassword("admin") },
                        new LoginModel() { Id =  Guid.NewGuid(), Username = "user1", Password = BCrypt.Net.BCrypt.HashPassword("user1") },
                });
            modelBuilder.Entity<GeoLocationData>()
                .HasData(new GeoLocationData[]
                {
                        new GeoLocationData() { Id =  Guid.NewGuid(), HostAddress = "127.0.0.1", CountryCode = "No code", CountryName = "No name" }
                });
        }
    }
}
