using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRProject.BusinessLayer.Abstract;
using SignalRProject.DtoLayer.AboutDto;
using SignalRProject.EntityLayer.Concrete;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        [HttpGet]
        public IActionResult AboutList()
        {
            var value=_aboutService.TGetListAll();
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateAbout(CreateAboutDto createAboutDto)
        {
            About about = new About()
            {
                Description = createAboutDto.Description,
                ImageUrl = createAboutDto.ImageUrl,
              Title = createAboutDto.Title,
              
            };
            _aboutService.TInsert(about);
            return Ok("Hakkımda kısmı basarılı bir şekilde eklendi");
        }
        [HttpDelete]
        public IActionResult DeleteAbout(int id)
        {
            _aboutService.TDelete(id);
            return Ok("Silme işleminiz başarılı bir şekilde gerçekleşti");
        }
        [HttpPut]
        public IActionResult UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            About about = new About()
            {
                AboutId = updateAboutDto.AboutId,
                Title = updateAboutDto.Title,   
                Description = updateAboutDto.Description,
                ImageUrl= updateAboutDto.ImageUrl,
            };
            _aboutService.TUpdate(about);
            return Ok("Güncelleme işleminiz başarılı bir şekilde gerçekleşti");
        }
        [HttpGet("GetAbout")]
        public IActionResult GetAbout(int id) 
        {
            var value=_aboutService.TGetById(id);
            return Ok(value);
        }
        
        
    }
}
