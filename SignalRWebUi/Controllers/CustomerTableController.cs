using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRProject.DtoLayer.MenuTableDtos;

namespace SignalRWebUi.Controllers
{
    public class CustomerTableController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CustomerTableController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> CustomerTableList()
        {
            var client=_httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7009/api/MenuTable");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData=await responseMessage.Content.ReadAsStringAsync();
                var value=JsonConvert.DeserializeObject<List<ResultMenuTableDto>>(jsonData);
                return View(value);
            }
            return View();
        }
    }
}
