using AutoMapper;
using SignalRProject.DtoLayer.BookingDtos;
using SignalRProject.EntityLayer.Concrete;

namespace SignalRApi.Mapping
{
    public class BookingMapping:Profile
    {
        public BookingMapping()
        {
            CreateMap<Booking , ResultBookingDto>().ReverseMap();
            CreateMap<Booking , CreateBookingDto>().ReverseMap();
            CreateMap<Booking , UpdateBookingDto>().ReverseMap();
            CreateMap<Booking , GetBookingDto>().ReverseMap();
        }
    }
}
