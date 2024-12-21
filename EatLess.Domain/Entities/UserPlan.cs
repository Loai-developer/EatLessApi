using EatLess.Domain.Primitives;
using EatLess.Domain.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace EatLess.Domain.Entities
{
    public sealed class UserPlan : Entity
    {
        [ForeignKey("UserData")]
        public Guid UserDataId { get; private set; }
        public GenderEnum GenderEnum { get; private set; }
        public BulkOrCutEnum BulkOrCutEnumType { get; private set; }
        public UserData UserData { get; private set; }
        public DateTime CreationDate { get; private set; }
        public decimal InitialWeight { get; private set; }
        public decimal TargetWeight { get; private set; }
        public int PlanPeriodInWeeks { get; private set; }
        //internal UserPlan(Guid Id, Guid mealId, Guid foodItemId, decimal quantity)
        //    : base(Id)
        //{
        //    MealId = mealId;
        //    FoodItemId = foodItemId;
        //    Quantity = quantity;
        //}
    }
}
