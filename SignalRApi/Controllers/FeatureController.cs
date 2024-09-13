using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRProject.BusinessLayer.Abstract;
using SignalRProject.DtoLayer.FeatureDtos;
using SignalRProject.EntityLayer.Concrete;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureController : ControllerBase
    {
        private readonly IFeatureService _featureService;

        public FeatureController(IFeatureService featureService)
        {
            _featureService = featureService;
        }
        [HttpGet]
        public IActionResult ListFeature()
        {
            var value = _featureService.TGetListAll();
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateFeature(CreateFeatureDto createFeatureDto) 
        {
            Feature feature = new Feature()
            {
                Description1 = createFeatureDto.Description1,
                Description2 = createFeatureDto.Description2,
                Description3 = createFeatureDto.Description3,
                Title1 = createFeatureDto.Title1,
                Title2 = createFeatureDto.Title2,
                Title3 = createFeatureDto.Title3,
                
            };
            _featureService.TInsert(feature);
            return Ok("İşleminiz başarıyla gerçekleşti");
        }

        [HttpDelete]
        public IActionResult DeleteFeature(int id) 
        {
            _featureService.TDelete(id);
            return Ok("İşleminiz başarıyla gerçekleşti");
        }
        [HttpPut]
        public IActionResult UpdateFeature(UpdateFeatureDto updateFeatureDto) 
        {
            Feature feature = new Feature()
            {
                Description1=updateFeatureDto.Description1,
                Description2=updateFeatureDto.Description2,
                Description3 = updateFeatureDto.Description3,
                Title1 = updateFeatureDto.Title1,
                Title2 = updateFeatureDto.Title2,
                Title3 = updateFeatureDto.Title3,
                FeatureId=updateFeatureDto.FeatureId
            };
            _featureService.TUpdate(feature);
            return Ok("İşleminiz başarıyla gerçekleşti");
        }

        [HttpGet("GetFeature")]
        public IActionResult GetFeature(int id) 
        {
            var value=_featureService.TGetById(id);
            return Ok(value);
        }


    }
}
