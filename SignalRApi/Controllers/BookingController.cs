using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRProject.BusinessLayer.Abstract;
using SignalRProject.DtoLayer.BookingDtos;
using SignalRProject.EntityLayer.Concrete;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        private readonly IMapper _mapper;

        public BookingController(IBookingService bookingService, IMapper mapper)
        {
            _bookingService = bookingService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult BookingList()
        {
            var value = _bookingService.TGetListAll();
            return Ok(_mapper.Map<List<ResultBookingDto>>(value));
        }
        [HttpPost]
        public IActionResult CreateBooking(CreateBookingDto createBookingDto)
        {
            var value=_mapper.Map<Booking>(createBookingDto);

            _bookingService.TInsert(value);
            return Ok("İşleminiz başarılı bir şekilde gerçekleşti");
        }
        [HttpDelete]
        public IActionResult DeleteBooking(int id)
        {
            _bookingService.TDelete(id);
            return Ok("İşleminiz başarılı bir şekilde gerçekleşti");
        }
        [HttpPut]
        public IActionResult UpdateBooking(UpdateBookingDto updateBookingDto) 
        {
            var value=_mapper.Map<Booking>(updateBookingDto);
            _bookingService.TUpdate(value);
            return Ok("İşleminiz başarılı bir şekilde gerçekleşti");
        }
        [HttpGet("GetBooking")]
        public IActionResult GetBooking(int id) 
        {
            var value=_bookingService.TGetById(id);
            return Ok(_mapper.Map<GetBookingDto>(value));
        }

        [HttpGet("BookingStatusApproved")]
        public IActionResult BookingStatusApproved(int id)
        {
           _bookingService.TBookingStatusApproved(id);
            return Ok("Rezarvasyon Açıklaması Değiştirildi");
        }

		[HttpGet("BookingStatusCancelled")]
		public IActionResult BookingStatusCancelled(int id)
		{
			_bookingService.TBookingStatusCancelled(id);
			return Ok("Rezarvasyon Açıklaması Değiştirildi");
		}

	}
}