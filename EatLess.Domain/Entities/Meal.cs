using EatLess.Domain.Primitives;
using EatLess.Domain.ValueObjects;

namespace EatLess.Domain.Entities
{
    public sealed class Meal : AggregateRoot
    {
        public MealName Name { get; private set; }
        public DateTime MealTime { get; private set; }
        public string? UserId { get; private set; } //null in case the meal is intoduced by the system
        private readonly List<MealComponent> _mealComponents = new();
        public IReadOnlyCollection<MealComponent> MealComponents => _mealComponents;
        private Meal(Guid Id, MealName name, DateTime mealTime, string? userId)
            :base(Id)
        {
            Name = name;
            MealTime = mealTime;
            UserId = userId;
        }

        public static Meal CreateMeal(Guid Id, string name, DateTime mealTime, string? userId)
        {
            var mealName = MealName.Create(name);

            if (mealName.IsFailure)
            {
                //Log error
                //return ;
            }
            var meal = new Meal(Id, MealName.Create(name).Value, mealTime, userId);
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
