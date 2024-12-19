using AutoMapper;
using EatLess.Application.ViewModels;
using EatLess.Domain.Entities;

namespace EatLess.Application.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<MealComponentVM, MealComponent>()
                .ForMember(dest => dest.FoodItemId , opt => opt.MapFrom(src => src.FoodItemId))
                .ForMember(dest => dest.Quantity , opt => opt.MapFrom(src => src.Quantity));

            CreateMap<MealComponent , MealComponentVM>();

            CreateMap<Meal, MealVM>()
                .ForMember(dest => dest.MealName , source => source.MapFrom(src => src.MealName.Value))
                .ReverseMap();
        }
    }
}
