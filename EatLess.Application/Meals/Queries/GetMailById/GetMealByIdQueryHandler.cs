using AutoMapper;
using EatLess.Application.ViewModels;
using EatLess.Domain.Abstractions.Messaging;
using EatLess.Domain.Repositories;
using EatLess.Domain.Shared;

namespace EatLess.Application.Meals.Queries.GetMailById
{
    public sealed class GetMealByIdQueryHandler : IQueryHandler<GetMealByIdQuery, MealVM>
    {
        private readonly IMealRepository _mealRepository;
        private readonly IMapper _mapper;
        public GetMealByIdQueryHandler(IMealRepository mealRepository, IMapper mapper )
        {
            _mealRepository = mealRepository;
            _mapper = mapper;
        }
        public async Task<Result<MealVM>> Handle(GetMealByIdQuery request, CancellationToken cancellationToken)
        {
            var Meal = await _mealRepository.GetMealByIdAsync(request.Id, cancellationToken);
            if (Meal == null) 
            {
                return Result.Failure<MealVM>(new Error("NotFound", $"Meal with Id {request.Id} is not found"));
            }
            return Result.Success(_mapper.Map<MealVM>(Meal));
        }
    }
}
