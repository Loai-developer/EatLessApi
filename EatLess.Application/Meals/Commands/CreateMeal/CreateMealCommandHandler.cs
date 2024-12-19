using AutoMapper;
using EatLess.Domain.Abstractions.Messaging;
using EatLess.Domain.Entities;
using EatLess.Domain.Repositories;
using EatLess.Domain.Shared;
using EatLess.Domain.ValueObjects;

namespace EatLess.Application.Meals.Commands.CreateMeal
{
    internal sealed class CreateMealCommandHandler : ICommandHandler<CreateMealCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMealRepository _mealRepository;
        private readonly IMapper _mapper;
        public CreateMealCommandHandler(IUnitOfWork unitOfWork, IMealRepository mealRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mealRepository = mealRepository;
            _mapper = mapper;
        }
        public async Task<Result> Handle(CreateMealCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var mealComponents = _mapper.Map<List<MealComponent>>(request.vm.MealComponents);
                var meal = Meal.CreateMeal(Guid.NewGuid(), request.vm.MealName, request.vm.MealTime, "");
                meal.AddMealComponentList(mealComponents);
                _mealRepository.Add(meal);
                await _unitOfWork.SaveChangesAsync(cancellationToken);
                return Result.Success();
            }
            catch (Exception ex) 
            {
                return Result.Failure(new Error("Error", $"Error with Message{ex.Message} has occured"));
            }
        }
    }
}
