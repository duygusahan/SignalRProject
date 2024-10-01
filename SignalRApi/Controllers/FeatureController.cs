using AutoMapper;
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
        private readonly IMapper _mapper;

        public FeatureController(IFeatureService featureService, IMapper mapper)
        {
            _featureService = featureService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult ListFeature()
        {
            var value = _featureService.TGetListAll();
            return Ok(_mapper.Map<List<ResultFeatureDto>>(value));
        }
        [HttpPost]
        public IActionResult CreateFeature(CreateFeatureDto createFeatureDto) 
        {
            var value=_mapper.Map<Feature>(createFeatureDto);
            _featureService.TInsert(value);
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
            var value=_mapper.Map<Feature>(updateFeatureDto);
            _featureService.TUpdate(value);
            return Ok("İşleminiz başarıyla gerçekleşti");
        }

        [HttpGet("GetFeature")]
        public IActionResult GetFeature(int id) 
        {
            var value=_featureService.TGetById(id);
            return Ok(_mapper.Map<GetFeatureDto>(value));
        }


    }
}
