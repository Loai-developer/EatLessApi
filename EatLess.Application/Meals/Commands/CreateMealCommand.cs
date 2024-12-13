using EatLess.Application.ViewModels;
using EatLess.Domain.Abstractions.Messaging;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EatLess.Application.Meals.Commands
{
    public sealed record CreateMealCommand(MealVM vm) : ICommand;
}
