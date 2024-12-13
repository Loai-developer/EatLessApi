using AutoMapper;
using EatLess.Application.ViewModels;
using EatLess.Domain.Entities;

namespace EatLess.Application.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<MealComponentVM, MealComponent>().ReverseMap();
        }
    }
}
