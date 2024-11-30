using EatLess.Domain.Entities;
using EatLess.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EatLess.Infrastructure.Repositories
{
    public sealed class MealRepository : IMealRepository
    {
        private readonly ApplicationDbContext _context;
        public MealRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Meal> GetMealByIdAsync(Guid Id, CancellationToken cancellationToken = default)
        {
            return await _context.Set<Meal>().Include(m => m.MealComponents).FirstOrDefaultAsync(m => m.Id == Id, cancellationToken);
        }

        public async Task<List<Meal>> GetListOfMealsAsync()
        {
            return await _context.Set<Meal>().Include(m => m.MealComponents).ToListAsync();
        }

        public void Remove(Meal meal)
        {
            _context.Set<Meal>().Remove(meal);
        }

        public void Add(Meal meal)
        {
            _context.Set<Meal>().AddAsync(meal);
        }
    }
}
