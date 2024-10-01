using AutoMapper;
using SignalRProject.DtoLayer.MenuTableDtos;
using SignalRProject.EntityLayer.Concrete;

namespace SignalRApi.Mapping
{
    public class MenuTableMapping:Profile
    {
        public MenuTableMapping() 
        {
            CreateMap<MenuTable , ResultMenuTableDto>().ReverseMap();
            CreateMap<MenuTable , CreateMenuTableDto>().ReverseMap();
            CreateMap<MenuTable , UpdateMenuTableDto>().ReverseMap();
            CreateMap<MenuTable , GetEMenuTableDto>().ReverseMap();
        }
    }
}
