using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRProject.BusinessLayer.Abstract;
using SignalRProject.DtoLayer.TestimonialDtos;
using SignalRProject.EntityLayer.Concrete;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService _testimonialService;
        private readonly IMapper _mapper;

        public TestimonialController(ITestimonialService testimonialService, IMapper mapper)
        {
            _testimonialService = testimonialService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult ListTestimonial()
        {
            var value = _testimonialService.TGetListAll();
            return Ok(_mapper.Map<List<ResultTestimonialDto>>(value));
        }
        [HttpPost]
        public IActionResult CreateTestimonial(CreateTestimonialDto createTestimonialDto)
        {
            var value=_mapper.Map<Testimonial>(createTestimonialDto);
            _testimonialService.TInsert(value);
            return Ok("İşleminiz başarıyla gerçekleşti");
        }

        [HttpDelete]
        public IActionResult DeleteTestimonial(int id)
        {
            _testimonialService.TDelete(id);
            return Ok("İşleminiz başarıyla gerçekleşti");
        }
        [HttpPut]
        public IActionResult UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
        {
            var value = _mapper.Map<Testimonial>(updateTestimonialDto);

            _testimonialService.TUpdate(value);
            return Ok("İşleminiz başarıyla gerçekleşti");
        }

        [HttpGet("GetTestimonial")]
        public IActionResult GetTestimonial(int id) 
        {
            var value=_testimonialService.TGetById(id);
            return Ok(_mapper.Map<GetTestimonialDto>(value));   
        }

        [HttpGet("GetTestimonialsByStatusTrue")]
        public IActionResult GetTestimonialsByStatusTrue()
        {
            var value  =_testimonialService.TGetTestimonialsByStatusTrue();
            return Ok(value);
        }
        [HttpGet("ChangeStatusToFalseTestimonials")]
        public IActionResult ChangeStatusToFalseTestimonials(int id)
        {
            _testimonialService.TChangeStatusToFalseTestimonials(id);
            return Ok("Referans Durumu Değiştirildi");
        }

        [HttpGet("ChangeStatusToTrueTestimonials")]
        public IActionResult ChangeStatusToTrueTestimonials(int id)
        {
            _testimonialService.TChangeStatusToTrueTestimonials(id);
            return Ok("Referans Durumu Değiştirildi");
        }

    }
}
