using EatLess.Domain.Primitives;

namespace EatLess.Domain.Entities
{
    public class FoodItem : Entity
    {
        public string Name { get;private set; }
        public string CaloriesPer100g { get;private set; }
        public string Photo { get;private set; }
        public enum Type
        {
            Protein = 1,
            Carb = 2,
            Fat = 3
        }
    }
}
