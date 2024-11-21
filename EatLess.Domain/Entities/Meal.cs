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
    public class Meal : Entity
    {
        public string Name { get; private set; }
        public DateTime MealTime { get; private set; }
        public string? UserId { get; private set; } //null in case the meal is intoduced by the system
        public virtual Collection<MealComponent> MealComponents { get;private set; }
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
