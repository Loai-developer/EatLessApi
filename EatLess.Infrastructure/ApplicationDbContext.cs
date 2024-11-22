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
            .Entity<FoodItem>()
            .Property(e => e.FoodTypeEnum)
            .HasColumnType("nvarchar(24)");
            modelBuilder
            .Entity<FoodItem>()
            .Property(e => e.FoodTypeEnum)
            .HasConversion(
                v => v.ToString(),
                v => (FoodTypeEnum)Enum.Parse(typeof(FoodTypeEnum), v));

        }

        DbSet<Meal> meals { get; set; }
        DbSet<MealComponent> mealComponents { get; set; }
        DbSet<FoodItem> foodItems { get; set; }
    }
}
