using EatLess.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EatLess.Domain.Entities
{
    public sealed class MealComponent : Entity
    {
        [ForeignKey("Meal")]
        public Guid MealId { get; private set; }
        [ForeignKey("FoodItem")]
        public Guid FoodItemId { get; private set; }
        public FoodItem FoodItem { get; private set; }
        public decimal Quantity { get;private set; }
        public Meal Meal { get; set; }

        //Internal constructor so it could be instantiated from inside the Meal class and wherever 
        //in the domain project
        internal MealComponent(Guid Id, Guid mealId, Guid foodItemId, decimal quantity) 
            :base(Id)
        { 
            MealId = mealId;
            FoodItemId = foodItemId;
            Quantity = quantity;
        }
    }
}
