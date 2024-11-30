using EatLess.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EatLess.Domain.Repositories
{
    public interface IMealRepository
    {
        Task<List<Meal>> GetListOfMealsAsync();
        Task<Meal> GetMealByIdAsync(Guid Id, CancellationToken cancellationToken);
        void Add(Meal meal);
        void Remove(Meal meal);
    }
}
