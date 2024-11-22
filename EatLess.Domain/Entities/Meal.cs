using EatLess.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EatLess.Domain.Entities
{
    public sealed class Meal : Entity
    {
        public string Name { get; private set; }
        public DateTime MealTime { get; private set; }
        public string? UserId { get; private set; } //null in case the meal is intoduced by the system
        private readonly List<MealComponent> _mealComponents = new();
        public IReadOnlyCollection<MealComponent> MealComponents => _mealComponents;
        private Meal(Guid Id, string name, DateTime mealTime, string? userId)
            :base(Id)
        {
            Name = name;
            MealTime = mealTime;
            UserId = userId;
        }

        public static Meal CreateMeal(Guid Id, string name, DateTime mealTime, string? userId)
        {
            var meal = new Meal(Id, name, mealTime, userId);
            return meal;
        }

        public MealComponent AddMealComponent(Guid Id, FoodItem foodItem, decimal quantity)
        {
            var MealComponent = new MealComponent(Id, this.Id, quantity);
            _mealComponents.Add(MealComponent);
            return MealComponent;
        }
    }
}
