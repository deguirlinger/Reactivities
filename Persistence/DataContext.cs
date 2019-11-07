using System;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<WeatherForecast> WeatherForecasts { get; set; }
        public DbSet<Activity> Activities { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<WeatherForecast>()
            .HasData(
                new WeatherForecast
                {
                    Id = 1,
                    Date = DateTime.Now.AddDays(1),
                    TemperatureC = -7,
                    Summary = "Frigid"
                },
                new WeatherForecast
                {
                    Id = 2,
                    Date = DateTime.Now.AddDays(2),
                    TemperatureC = 37,
                    Summary = "Human"
                },
                new WeatherForecast
                {
                    Id = 3,
                    Date = DateTime.Now.AddDays(3),
                    TemperatureC = 23,
                    Summary = "Perfection"
                }
            );
        }
    }
}
