using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NuGet.Versioning;
using SignalRProject.DtoLayer.BookingDtos;
using System.Text;

namespace SignalRWebUi.Controllers
{
    public class BookATableController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BookATableController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult CreateBooking()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBooking(CreateBookingDto createBookingDto)
        {
            createBookingDto.Description = "Rezarvasyon Alındı";
            var client =_httpClientFactory.CreateClient();
            var jsonData=JsonConvert.SerializeObject(createBookingDto);
            StringContent stringContent = new StringContent(jsonData , Encoding.UTF8 , "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7009/api/Booking", stringContent);
            if (responseMessage.IsSuccessStatusCode) 
            {
                return RedirectToAction("CreateBooking");
            }
            else
            {
                var errorContent=await responseMessage.Content.ReadAsStringAsync();
                ModelState.AddModelError(string.Empty, errorContent);
                return View();
             }
        }
    }
}
