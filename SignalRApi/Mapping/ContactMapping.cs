using AutoMapper;
using SignalRProject.DtoLayer.ContactDtos;
using SignalRProject.EntityLayer.Concrete;

namespace SignalRApi.Mapping
{
    public class ContactMapping:Profile
    {
        public ContactMapping()
        {
            CreateMap<Contact , ResultContactDto>().ReverseMap();
            CreateMap<Contact , CreateContactDto>().ReverseMap();
            CreateMap<Contact , UpdateContactDto>().ReverseMap();
            CreateMap<Contact , GetContactDto>().ReverseMap();
        }
    }
}
