using AutoMapper;
using SignalRProject.DtoLayer.ProductDtos;
using SignalRProject.EntityLayer.Concrete;

namespace SignalRApi.Mapping
{
    public class ProductMapping:Profile
    {
        public ProductMapping()
        {
            CreateMap<Product , ResultProductDto>().ReverseMap();
            CreateMap<Product , CreateProductDto>().ReverseMap();
            CreateMap<Product , UpdateProductDto>().ReverseMap();
            CreateMap<Product , GetProductDto>().ReverseMap();
        }
    }
}
