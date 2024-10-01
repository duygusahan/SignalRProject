using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRProject.BusinessLayer.Abstract;
using SignalRProject.DtoLayer.SocialMediaDtos;
using SignalRProject.EntityLayer.Concrete;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController : ControllerBase
    {
        private readonly ISocialMediaService _socialMediaService;
        private readonly IMapper _mapper;

        public SocialMediaController(ISocialMediaService socialMediaService, IMapper mapper)
        {
            _socialMediaService = socialMediaService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult SocialMediaList()
        {
            var value = _socialMediaService.TGetListAll();
            return Ok(_mapper.Map<List<ResultSocialMediaDto>>(value));
        }
        [HttpPost]
        public IActionResult CreateSocialMedia(CreateSocialMediaDto createSocialMediaDto)
        {
            var value=_mapper.Map<SocialMedia>(createSocialMediaDto);
            _socialMediaService.TInsert(value);
            return Ok("İşleminiz başarıyla gerçekleşti"); 
        }
        [HttpDelete]
        public IActionResult DeleteSocialMedia(int id) 
        {
            _socialMediaService.TDelete(id);
            return Ok("İşleminiz başarıyla gerçekleşti");
        }
        [HttpPut]
        public IActionResult UpdateSocialMedia(UpdateSocialMedia updateSocialMedia)
        {
           var value=_mapper.Map<SocialMedia>(updateSocialMedia);
            _socialMediaService.TUpdate(value);
            return Ok("İşleminiz başarıyla gerçekleşti");
        }
        [HttpGet("GetSocialMedia")]
        public IActionResult GetSocialMedia(int id) 
        {
            var value=_socialMediaService.TGetById(id);
            return Ok(_mapper.Map<GetSocialMediaDto>(value));
        }

    }
}
