using AutoMapper;
using SignalRProject.DtoLayer.NotificationDtos;

namespace SignalRApi.Mapping
{
    public class NotificationMapping:Profile
    {
        public NotificationMapping()
        {
            CreateMap<NotificationMapping , ResultNotificationDto>().ReverseMap();
            CreateMap<NotificationMapping , CreateNotificationDto>().ReverseMap();
            CreateMap<NotificationMapping , UpdateNotification>().ReverseMap();
            CreateMap<NotificationMapping , GetNotificationDto>().ReverseMap();
        }
    }
}
