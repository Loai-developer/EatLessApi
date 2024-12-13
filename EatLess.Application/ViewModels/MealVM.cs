using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EatLess.Application.ViewModels
{
    public sealed class MealVM
    {
        public Guid Id { get; set; }
        public string MealName { get; set; }
        public DateTime MealTime { get; set; }
        public List<MealComponentVM> MealComponents { get; set; }
    }

    public sealed class MealComponentVM
    {
        public Guid Id { get; set; }
        public Guid MealId { get; set; }
        public Guid FoodItemId { get; set; }
        public decimal Quantity { get; set; }
    }
}
