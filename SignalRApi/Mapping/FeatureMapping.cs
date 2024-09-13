using AutoMapper;
using SignalRProject.DtoLayer.FeatureDtos;
using SignalRProject.EntityLayer.Concrete;

namespace SignalRApi.Mapping
{
    public class FeatureMapping:Profile
    {
        public FeatureMapping()
        {
            CreateMap<Feature , ResultFeatureDto>().ReverseMap();
            CreateMap<Feature , CreateFeatureDto>().ReverseMap();
            CreateMap<Feature , UpdateFeatureDto>().ReverseMap();
            CreateMap<Feature , GetFeatureDto>().ReverseMap();
        }
    }
}
