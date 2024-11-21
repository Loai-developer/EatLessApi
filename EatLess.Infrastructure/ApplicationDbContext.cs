using EatLess.Domain.Entities;
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
            base.OnModelCreating(modelBuilder);
        }

        DbSet<Meal> meals { get; set; }
        DbSet<MealComponent> mealComponents { get; set; }
        DbSet<FoodItem> foodItems { get; set; }
    }
}
