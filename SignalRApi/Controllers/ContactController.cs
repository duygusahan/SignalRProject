using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRProject.BusinessLayer.Abstract;
using SignalRProject.DtoLayer.ContactDtos;
using SignalRProject.EntityLayer.Concrete;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;

        public ContactController(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult ContactList()
        {
            var value=_contactService.TGetListAll();
            return Ok(_mapper.Map<List<ResultContactDto>>(value));
        }
        [HttpPost]
        public IActionResult CreateContact(CreateContactDto createContactDto)
        {
            var value = _mapper.Map<Contact>(createContactDto);

            _contactService.TInsert(value);
            return Ok("İşleminiz başarılı bir şekilde gerçekleşti"); 
        }
        [HttpDelete]
        public IActionResult DeleteContact(int id) 
        {
            _contactService.TDelete(id);
            return Ok("İşleminiz başarılı bir şekilde gerçekleşti");
        }
        [HttpPut]
        public IActionResult UpdateContact(UpdateContactDto updateContactDto)
        {
            var value=_mapper.Map<Contact>(updateContactDto);
            _contactService.TUpdate(value);
            return Ok("İşleminiz başarılı bir şekilde gerçekleşti");
        }

        [HttpGet("GetContact")]
        public IActionResult GetContact(int id) 
        {
            var value=_contactService.TGetById(id);
            return Ok(_mapper.Map<GetContactDto>(value));
        }
    }
}
