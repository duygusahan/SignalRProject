using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRProject.BusinessLayer.Abstract;
using SignalRProject.DtoLayer.DiscountDtos;
using SignalRProject.EntityLayer.Concrete;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;
        private readonly IMapper _mapper;

        public DiscountController(IDiscountService discountService, IMapper mapper)
        {
            _discountService = discountService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult ListDiscount()
        {
            var value = _discountService.TGetListAll();
            return Ok(_mapper.Map<List<ResultDiscountDto>>(value));
        }
        [HttpPost]
        public IActionResult CreateDiscount(CreateDiscountDto createDiscountDto)
        {
           var value=_mapper.Map<Discount>(createDiscountDto);
            _discountService.TInsert(value);
            return Ok("İşleminiz başarılı bir şekilde gerçekleşti");
        }

        [HttpDelete]
        public IActionResult DeleteDiscount(int id)
        {
            _discountService.TDelete(id);
            return Ok("İşleminiz başarılı bir şekilde gerçekleşti");
        }

        [HttpPut]
        public IActionResult UpdateDiscount(UpdateDiscountDto updateDiscountDto)
        {
            var value=_mapper.Map<Discount>(updateDiscountDto);
            _discountService.TUpdate(value);
            return Ok("İşleminiz başarılı bir şekilde gerçekleşti");
        }
        [HttpGet("GetDiscount")]
        public IActionResult GetDiscount(int id)
        {
            var value=_discountService.TGetById(id);
            return Ok(_mapper.Map<GetDiscountDto>(value));
        }
        [HttpGet("ChangeStatusToFalse")]
        public IActionResult ChangeStatusToFalse(int id)
        {
            _discountService.TChangeStatusToFalse(id);
            return Ok("Durum Değiştirildi");
        }

        [HttpGet("ChangeStatusToTrue")]
        public IActionResult ChangeStatusToTrue(int id)
        {
            _discountService.TChangeStatusToTrue(id);
            return Ok("Durum Değiştirildi");
        }
        [HttpGet("GetDiscountByStatusTrue")]
        public IActionResult GetDiscountByStatusTrue()
        {
           var value= _discountService.TGetDiscountByStatusTrue();
            return Ok(value);
        }
    }
}
