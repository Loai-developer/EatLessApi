using EatLess.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EatLess.Domain.Entities
{
    public class MealComponent : Entity
    {
        public FoodItem FoodItem { get; private set; }
        public decimal Quantity { get;private set; }
        [ForeignKey("Meal")]
        public Guid MealId { get; private set; }
        public Meal Meal { get; set; }
    }
}
