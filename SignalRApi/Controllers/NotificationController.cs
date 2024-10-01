using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRProject.BusinessLayer.Abstract;
using SignalRProject.DtoLayer.NotificationDtos;
using SignalRProject.EntityLayer.Concrete;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationsService _notificationsService;
        private readonly IMapper _mapper;

        public NotificationController(INotificationsService notificationsService, IMapper mapper)
        {
            _notificationsService = notificationsService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult NotificationList()
        {
            var value = _notificationsService.TGetListAll();
            return Ok(_mapper.Map<List<ResultNotificationDto>>(value));

        }

        [HttpGet("NotificationCountByStatusFalse")]
        public IActionResult NotificationCountByStatusFalse()
        {
            var value = _notificationsService.TNotificationCountByStatusFalse();
            return Ok(value);
        }
        [HttpGet("GetAllNotificationsByFalse")]
        public IActionResult GetAllNotificationsByFalse()
        {
            var value = _notificationsService.TGetAllNotificationsByFalse();
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateNotification(CreateNotificationDto createNotificationDto)
        {
            var value=_mapper.Map<Notification>(createNotificationDto);
            _notificationsService.TInsert(value);
            return Ok("Ekleme işlemi gerçekleşti");
        }
        [HttpDelete]
        public IActionResult DeleteNotification(int id) {
            _notificationsService.TDelete(id);
            return Ok("Silme işleminiz başarılı bir şekilde gerçekleşti");
        }

        [HttpGet("GetNotification")]
        public IActionResult GetNotification(int id) 
        {
            var value=_notificationsService.TGetById(id);
            return Ok(_mapper.Map<UpdateNotification>(value));   
        }

        [HttpPut]
        public IActionResult UpdateNotification(UpdateNotification updateNotification)
        {
           var value=_mapper.Map<Notification>(updateNotification);
            _notificationsService.TUpdate(value);
            return Ok("Güncelleme işlemi gerçekleşti");
        }

        [HttpGet("NotificationStatusChangeToTrue")]
        public IActionResult NotificationStatusChangeToTrue(int id) 
        {
            _notificationsService.TNotificationStatusChangeToTrue(id);
            return Ok("işleminiz gerçekleşti");
        }

        [HttpGet("NotificationStatusChangeToFalse")]
        public IActionResult NotificationStatusChangeToFalse(int id)
        {
            _notificationsService.TNotificationStatusChangeToFalse(id);
            return Ok("işleminiz gerçekleşti");
        }
    }
}
