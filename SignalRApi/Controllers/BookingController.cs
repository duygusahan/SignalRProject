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

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }
        [HttpGet]
        public IActionResult BookingList()
        {
            var value = _bookingService.TGetListAll();
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateBooking(CreateBookingDto createBookingDto)
        {
            Booking booking = new Booking()
            {
                Date = createBookingDto.Date,
                Mail = createBookingDto.Mail,
                Name = createBookingDto.Name,
                PersonCount = createBookingDto.PersonCount,
                Phone = createBookingDto.Phone,
                Description = createBookingDto.Description, 
               

            };

            _bookingService.TInsert(booking);
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
            Booking booking = new Booking()
            {
                Date= updateBookingDto.Date,
                Mail = updateBookingDto.Mail,
                Name = updateBookingDto.Name,   
                PersonCount = updateBookingDto.PersonCount,
                Phone = updateBookingDto.Phone,
                BookingId = updateBookingDto.BookingId
                
            };  
            _bookingService.TUpdate(booking);
            return Ok("İşleminiz başarılı bir şekilde gerçekleşti");
        }
        [HttpGet("GetBooking")]
        public IActionResult GetBooking(int id) 
        {
            var value=_bookingService.TGetById(id);
            return Ok(value);
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