using AutoMapper;
using SignalRProject.DtoLayer.SocialMediaDtos;
using SignalRProject.EntityLayer.Concrete;

namespace SignalRApi.Mapping
{
    public class SocialMediaMapping:Profile
    {
        public SocialMediaMapping()
        {
            CreateMap<SocialMedia , ResultSocialMediaDto>().ReverseMap();
            CreateMap<SocialMedia , CreateSocialMediaDto>().ReverseMap();
            CreateMap<SocialMedia , UpdateSocialMedia>().ReverseMap();
            CreateMap<SocialMedia , GetSocialMediaDto>().ReverseMap();
        }
    }
}
