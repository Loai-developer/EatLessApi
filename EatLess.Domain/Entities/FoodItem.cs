using EatLess.Domain.Primitives;
using EatLess.Domain.Shared;

namespace EatLess.Domain.Entities
{
    public sealed class FoodItem : Entity
    {
        public string Name { get;private set; }
        public decimal CaloriesPerOneGram { get;private set; }
        public string Photo { get;private set; }
        public FoodTypeEnum FoodTypeEnum { get; private set; }
        internal FoodItem(Guid Id, string name, decimal caloriesPerOneGram, string photo)
            :base(Id)
        {
            Name = name;
            CaloriesPerOneGram = caloriesPerOneGram;
            Photo = photo;
            //FoodType = FoodTypeEnum.FromValue(type);
        }
    }

}
