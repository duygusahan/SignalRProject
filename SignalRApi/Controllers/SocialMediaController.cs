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

        public SocialMediaController(ISocialMediaService socialMediaService)
        {
            _socialMediaService = socialMediaService;
        }
        [HttpGet]
        public IActionResult SocialMediaList()
        {
            var value = _socialMediaService.TGetListAll();
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateSocialMedia(CreateSocialMediaDto createSocialMediaDto)
        {
            SocialMedia socialMedia = new SocialMedia()
            {
                Icon = createSocialMediaDto.Icon,
                Title = createSocialMediaDto.Title,
                Url = createSocialMediaDto.Url,
            };
            _socialMediaService.TInsert(socialMedia);
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
            SocialMedia socialMedia = new SocialMedia()
            {
                Icon=updateSocialMedia.Icon,
                Title=updateSocialMedia.Title,
                Url = updateSocialMedia.Url,
                SocialMediaId=updateSocialMedia.SocialMediaId,
            };
            _socialMediaService.TUpdate(socialMedia);
            return Ok("İşleminiz başarıyla gerçekleşti");
        }
        [HttpGet("GetSocialMedia")]
        public IActionResult GetSocialMedia(int id) 
        {
            var value=_socialMediaService.TGetById(id);
            return Ok(value);
        }

    }
}
