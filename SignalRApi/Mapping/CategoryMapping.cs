using AutoMapper;
using SignalRProject.DtoLayer.CategoryDtos;
using SignalRProject.EntityLayer.Concrete;

namespace SignalRApi.Mapping
{
    public class CategoryMapping:Profile
    {
        public CategoryMapping()
        {
            CreateMap<Category , ResultCategoryDto>().ReverseMap();
            CreateMap<Category , CreateCategoryDto>().ReverseMap();
            CreateMap<Category , UpdateCategoryDto>().ReverseMap();
            CreateMap<Category , GetCategoryDto>().ReverseMap();
        }
    }
}
