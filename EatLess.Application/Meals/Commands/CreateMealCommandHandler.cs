using EatLess.Domain.Abstractions.Messaging;
using EatLess.Domain.Entities;
using EatLess.Domain.Repositories;
using EatLess.Domain.Shared;
using EatLess.Domain.ValueObjects;

namespace EatLess.Application.Meals.Commands
{
    internal sealed class CreateMealCommandHandler : ICommandHandler<CreateMealCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMealRepository _mealRepository;
        public CreateMealCommandHandler(IUnitOfWork unitOfWork, IMealRepository mealRepository) 
        { 
            _unitOfWork = unitOfWork;
            _mealRepository = mealRepository;
        }
        public async Task<Result> Handle(CreateMealCommand request, CancellationToken cancellationToken)
        {
            var mealName = MealName.Create(request.Name);
            var meal = Meal.CreateMeal(Guid.NewGuid(), request.Name , request.MealTime, "");
            _mealRepository.Add(meal);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Success();
        }
    }
}
