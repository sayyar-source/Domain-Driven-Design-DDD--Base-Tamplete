using AutoMapper;
using Portal.Application.Foods.Models;
using Portal.Domain;
using Portal.Domain.FoodAggregate;

namespace Portal.Application.FoodApplication.Mapper
{
    public class FoodMapper : Profile
    {
        public FoodMapper()
        {
            CreateMap<FoodAddInfo, Food>();
            CreateMap<Food, FoodInfo>();
            CreateMap<Food, FoodEditInfo>().ReverseMap();
        }
    }
}