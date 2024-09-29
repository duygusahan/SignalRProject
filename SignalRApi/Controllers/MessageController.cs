using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRProject.BusinessLayer.Abstract;
using SignalRProject.DtoLayer.MessageDtos;
using SignalRProject.EntityLayer.Concrete;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }
        [HttpGet]
        public IActionResult MessageList()
        {
            var value = _messageService.TGetListAll();
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateMessage(CreateMessageDto createMessageDto)
        {
            Message message = new Message()
            {
                Mail = createMessageDto.Mail,
                MessageContent = createMessageDto.MessageContent,
                NameSurname = createMessageDto.NameSurname,
                Phone = createMessageDto.Phone,
                SendDate = createMessageDto.SendDate,
                Status = createMessageDto.Status,
                Subject = createMessageDto.Subject,

            };
            _messageService.TInsert(message);
            return Ok("Mesajınız Kaydedildi");
        }

        [HttpDelete]
        public IActionResult DeleteMessage(int id) 
        {
            _messageService.TDelete(id);
            return Ok("Mesajınız Silindi");
        }

        [HttpPut]
        public IActionResult UpdateMessage(UpdateMessageDto updateMessageDto)
        {
            Message message = new Message()
            {
                MessageId = updateMessageDto.MessageId, 
                Mail = updateMessageDto.Mail,
                MessageContent = updateMessageDto.MessageContent,
                NameSurname = updateMessageDto.NameSurname,
                Phone = updateMessageDto.Phone,
                SendDate = updateMessageDto.SendDate,
                Status = updateMessageDto.Status,
                Subject = updateMessageDto.Subject,
            };
            _messageService.TUpdate(message);
            return Ok("Mesajınız Güncellendi");
        }

        [HttpGet("GetMessage")]
        public IActionResult GetMessage(int id) 
        {
            var value=_messageService.TGetById(id);
            return Ok(value);
        }
    }
}
