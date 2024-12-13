using EatLess.Domain.Entities;
using EatLess.Domain.Shared;
using Microsoft.EntityFrameworkCore;

namespace EatLess.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
            .Entity<Meal>()
            .ComplexProperty(s => s.MealName, a =>
            {
                a.Property(p => p.Value).HasColumnName("Name");
            });

            modelBuilder
            .Entity<FoodItem>()
            .Property(e => e.FoodTypeEnum)
            .HasColumnName("FoodType");

        }

        DbSet<Meal> meals { get; set; }
        DbSet<MealComponent> mealComponents { get; set; }
        DbSet<FoodItem> foodItems { get; set; }
    }
}
