using AutoMapper;
using SignalRProject.DtoLayer.DiscountDtos;
using SignalRProject.EntityLayer.Concrete;

namespace SignalRApi.Mapping
{
    public class DiscountMapping:Profile
    {
        public DiscountMapping()
        {
            CreateMap<ResultDiscountDto , Discount>().ReverseMap();
            CreateMap<CreateDiscountDto , Discount>().ReverseMap();
            CreateMap<UpdateDiscountDto , Discount>().ReverseMap();
            CreateMap<GetDiscountDto , Discount>().ReverseMap();
        }
    }
}
