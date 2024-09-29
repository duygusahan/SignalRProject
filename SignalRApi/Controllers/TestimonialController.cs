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

        public TestimonialController(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }
        [HttpGet]
        public IActionResult ListTestimonial()
        {
            var value = _testimonialService.TGetListAll();
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateTestimonial(CreateTestimonialDto createTestimonialDto)
        {
            Testimonial testimonial = new Testimonial()
            {
                Comment = createTestimonialDto.Comment,
                ImageUrl = createTestimonialDto.ImageUrl,
                Name = createTestimonialDto.Name,
                Status = createTestimonialDto.Status,
                Title = createTestimonialDto.Title,
            };
            _testimonialService.TInsert(testimonial);
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
            Testimonial testimonial = new Testimonial() { 
            Comment = updateTestimonialDto.Comment,
            ImageUrl= updateTestimonialDto.ImageUrl,
            Name = updateTestimonialDto.Name,
            Status = updateTestimonialDto.Status,   
            Title = updateTestimonialDto.Title, 
            TestimonialId=updateTestimonialDto.TestimonialId,
            };

            _testimonialService.TUpdate(testimonial);
            return Ok("İşleminiz başarıyla gerçekleşti");
        }

        [HttpGet("GetTestimonial")]
        public IActionResult GetTestimonial(int id) 
        {
            var value=_testimonialService.TGetById(id);
            return Ok(value);   
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
