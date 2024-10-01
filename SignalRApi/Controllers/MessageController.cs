using AutoMapper;
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
        private readonly IMapper _mapper;

        public MessageController(IMessageService messageService, IMapper mapper)
        {
            _messageService = messageService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult MessageList()
        {
            var value = _messageService.TGetListAll();
            return Ok(_mapper.Map<List<ResultMessageDto>>(value));
        }
        [HttpPost]
        public IActionResult CreateMessage(CreateMessageDto createMessageDto)
        {
            createMessageDto.Status = false;
            createMessageDto.SendDate = DateTime.Now;
            var value = _mapper.Map<Message>(createMessageDto);
            _messageService.TInsert(value);
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
           var value=_mapper.Map<Message>(updateMessageDto);
            _messageService.TUpdate(value);
            return Ok("Mesajınız Güncellendi");
        }

        [HttpGet("GetMessage")]
        public IActionResult GetMessage(int id) 
        {
            var value=_messageService.TGetById(id);
            return Ok(_mapper.Map<GetMessageDto>(value));
        }
    }
}
