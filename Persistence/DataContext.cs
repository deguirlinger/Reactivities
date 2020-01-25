using System;
using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
  public class DataContext : IdentityDbContext<AppUser>
  {
    public DataContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<WeatherForecast> WeatherForecasts { get; set; }
    public DbSet<Activity> Activities { get; set; }
    public DbSet<UserActivity> UserActivities { get; set; }
    public DbSet<Photo> Photos { get; set; }
    public DbSet<Comment> Comments { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      base.OnModelCreating(builder);

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

      builder.Entity<UserActivity>(x => x.HasKey(ua => new { ua.AppUserId, ua.ActivityId }));

      builder.Entity<UserActivity>()
        .HasOne(u => u.AppUser)
        .WithMany(a => a.UserActivities)
        .HasForeignKey(u => u.AppUserId);

      builder.Entity<UserActivity>()
        .HasOne(a => a.Activity)
        .WithMany(u => u.UserActivities)
        .HasForeignKey(a => a.ActivityId);
    }
  }
}
