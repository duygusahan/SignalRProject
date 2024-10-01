using AutoMapper;
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
        private readonly IMapper _mapper;
        public AboutController(IAboutService aboutService, IMapper mapper)
        {
            _aboutService = aboutService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult AboutList()
        {
            var value=_aboutService.TGetListAll();
            return Ok(_mapper.Map<List<ResultAboutDto>>(value));
        }
        [HttpPost]
        public IActionResult CreateAbout(CreateAboutDto createAboutDto)
        {
            var value=_mapper.Map<About>(createAboutDto);
            _aboutService.TInsert(value);
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
            var value=_mapper.Map<About>(updateAboutDto);
            _aboutService.TUpdate(value);
            return Ok("Güncelleme işleminiz başarılı bir şekilde gerçekleşti");
        }
        [HttpGet("GetAbout")]
        public IActionResult GetAbout(int id) 
        {
            var value=_aboutService.TGetById(id);
            return Ok(_mapper.Map<GetAboutDto>(value));
        }
        
        
    }
}
