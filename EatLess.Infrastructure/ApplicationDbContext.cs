using EatLess.Domain.Entities;
using EatLess.Domain.Shared;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EatLess.Infrastructure
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Added when identity is added and fixed an error in adding identity migrations
            base.OnModelCreating(modelBuilder);
            modelBuilder
            .Entity<Meal>()
            .ComplexProperty(s => s.MealName, a =>
            {
                a.Property(p => p.Value).HasColumnName("Name");
            });

            modelBuilder
            .Entity<FoodItem>()
            .Property(e => e.FoodTypeEnum)
            .HasConversion(
                v => v.ToString(),
                v => (FoodTypeEnum)Enum.Parse(typeof(FoodTypeEnum), v))
            .HasColumnName("FoodType");

            modelBuilder
            .Entity<FoodItem>()
            .HasData(new FoodItem(Guid.NewGuid(), "Rice", 140, FoodTypeEnum.Carb, "") ,
                     new FoodItem(Guid.NewGuid(), "ChickenBreasts", 165, FoodTypeEnum.Protein, "") ,
                     new FoodItem(Guid.NewGuid(), "Salad", 25, FoodTypeEnum.Fiber, "") ,
                     new FoodItem(Guid.NewGuid(), "ChickenSighs", 180, FoodTypeEnum.Protein, "") );
        }

        DbSet<Meal> meals { get; set; }
        DbSet<MealComponent> mealComponents { get; set; }
        DbSet<FoodItem> foodItems { get; set; }
    }
}
