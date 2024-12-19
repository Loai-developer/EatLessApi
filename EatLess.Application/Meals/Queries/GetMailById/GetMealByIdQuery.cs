using EatLess.Application.ViewModels;
using EatLess.Domain.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EatLess.Application.Meals.Queries.GetMailById
{
    public sealed record GetMealByIdQuery(Guid Id) : IQuery<MealVM>;
    
}
