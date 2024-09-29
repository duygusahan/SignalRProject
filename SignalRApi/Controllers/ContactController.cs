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

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }
        [HttpGet]
        public IActionResult ContactList()
        {
            var value=_contactService.TGetListAll();
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateContact(CreateContactDto createContactDto)
        {
            Contact contact = new Contact()
            {
                FooterDescription = createContactDto.FooterDescription,
                Location= createContactDto.Location,
                Mail= createContactDto.Mail,
                PhoneNumber= createContactDto.PhoneNumber,
            };

            _contactService.TInsert(contact);
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
            Contact contact = new Contact()
            {
                ContactId = updateContactDto.ContactId,
                FooterDescription = updateContactDto.FooterDescription,
                Location = updateContactDto.Location,
                Mail = updateContactDto.Mail,
                PhoneNumber = updateContactDto.PhoneNumber,
                FooterTitle= updateContactDto.FooterTitle,
                OpenDays= updateContactDto.OpenDays,
                OpenDaysDescription= updateContactDto.OpenDaysDescription,
                OpenHours= updateContactDto.OpenHours,

            };
            _contactService.TUpdate(contact);
            return Ok("İşleminiz başarılı bir şekilde gerçekleşti");
        }

        [HttpGet("GetContact")]
        public IActionResult GetContact(int id) 
        {
            var value=_contactService.TGetById(id);
            return Ok(value);
        }
    }
}
