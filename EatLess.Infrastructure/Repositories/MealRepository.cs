using EatLess.Domain.Abstractions;
using EatLess.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EatLess.Infrastructure.Repositories
{
    internal sealed class MealRepository : IMealRepository
    {
        private readonly ApplicationDbContext _context;
        public MealRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Insert(Meal meal)
        {
            _context.Set<Meal>().Add(meal);
        }
    }
}
