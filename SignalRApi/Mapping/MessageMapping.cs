using AutoMapper;
using SignalRProject.DtoLayer.MessageDtos;
using SignalRProject.EntityLayer.Concrete;

namespace SignalRApi.Mapping
{
    public class MessageMapping:Profile
    {
        public MessageMapping() 
        {
            CreateMap<ResultMessageDto , Message>().ReverseMap();
            CreateMap<CreateMessageDto , Message>().ReverseMap();
            CreateMap<UpdateMessageDto , Message>().ReverseMap();
            CreateMap<GetMessageDto , Message>().ReverseMap();
        }
    }
}
