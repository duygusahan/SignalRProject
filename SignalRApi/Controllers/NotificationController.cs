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

        public NotificationController(INotificationsService notificationsService)
        {
            _notificationsService = notificationsService;
        }

        [HttpGet]
        public IActionResult NotificationList()
        {
            var value = _notificationsService.TGetListAll();
            return Ok(value);

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
            Notification notification = new Notification()
            {
                Date = Convert.ToDateTime(DateTime.Now.ToShortDateString()),
                Description= createNotificationDto.Description,
                Icon = createNotificationDto.Icon,
                Status=false,  
                Type = createNotificationDto.Type,
            };
            _notificationsService.TInsert(notification);
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
            return Ok(value);   
        }

        [HttpPut]
        public IActionResult UpdateNotification(UpdateNotification updateNotification)
        {
            Notification notification = new Notification()
            {
                NotificationId= updateNotification.NotificationId,
                Date = updateNotification.Date,
                Description = updateNotification.Description,
                Icon = updateNotification.Icon,
                Status = updateNotification.Status,
                Type = updateNotification.Type,
            };
            _notificationsService.TUpdate(notification);
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
