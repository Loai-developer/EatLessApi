using EatLess.Domain.Primitives;
using EatLess.Domain.ValueObjects;

namespace EatLess.Domain.Entities
{
    public sealed class Meal : AggregateRoot
    {
        public MealName MealName { get; private set; }
        public DateTime MealTime { get; private set; }
        public string? UserId { get; private set; } //null in case the meal is intoduced by the system
        private readonly List<MealComponent> _mealComponents = new();
        public IReadOnlyCollection<MealComponent> MealComponents => _mealComponents;
        private Meal(Guid Id, MealName name, DateTime mealTime, string? userId)
            :base(Id)
        {
            MealName = name;
            MealTime = mealTime;
            UserId = userId;
        }
        public Meal() : base(Guid.Empty)
        {
        }

        public static Meal CreateMeal(Guid Id, string name, DateTime mealTime, string? userId)
        {
            var mealName = MealName.Create(name);

            if (mealName.IsFailure)
            {
                //Log error
                //return ;
            }
            var meal = new Meal(Id, mealName.Value, mealTime, userId);
            return meal;
        }

        public void AddMealComponent(Guid Id, Guid foodItemId, decimal quantity)
        {
            var MealComponent = new MealComponent(Id, this.Id, foodItemId, quantity);
            _mealComponents.Add(MealComponent);
        }

        public void AddMealComponentList(List<MealComponent> mealComponents)
        {
            foreach (var item in mealComponents)
            {
                var MealComponent = new MealComponent(Id, this.Id, item.FoodItemId, item.Quantity);
                _mealComponents.Add(MealComponent);
            }
        }

    }
}
