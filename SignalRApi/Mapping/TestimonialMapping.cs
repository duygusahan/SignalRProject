using AutoMapper;
using SignalRProject.DtoLayer.TestimonialDtos;
using SignalRProject.EntityLayer.Concrete;

namespace SignalRApi.Mapping
{
    public class TestimonialMapping:Profile
    {
        public TestimonialMapping()
        {
            CreateMap<Testimonial , ResultTestimonialDto>().ReverseMap();
            CreateMap<Testimonial , CreateTestimonialDto>().ReverseMap();
            CreateMap<Testimonial , UpdateTestimonialDto>().ReverseMap();
            CreateMap<Testimonial , GetTestimonialDto>().ReverseMap();
        }
    }
}
