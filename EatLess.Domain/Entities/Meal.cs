using EatLess.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EatLess.Domain.Entities
{
    public class Meal : Entity
    {
        public string Name { get; private set; }
        public DateTime MealTime { get; private set; }
        public string? UserId { get; private set; }

        public Meal(string name, DateTime mealTime, string? userId)
        {
            Name = name;
            MealTime = mealTime;
            UserId = userId;
        }

        private Meal()
        {
            
        }
    }
}
