using AutoMapper;
using SignalRProject.DtoLayer.DiscountDtos;
using SignalRProject.EntityLayer.Concrete;

namespace SignalRApi.Mapping
{
    public class DiscountMapping:Profile
    {
        public DiscountMapping()
        {
            CreateMap<Discount , ResultDiscountDto>().ReverseMap();
            CreateMap<Discount , CreateDiscountDto>().ReverseMap();
            CreateMap<Discount , UpdateDiscountDto>().ReverseMap();
            CreateMap<Discount , GetDiscountDto>().ReverseMap();
        }
    }
}
