using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRProject.DtoLayer.ContactDtos;

namespace SignalRWebUi.ViewComponents.UILayoutComponents
{
    public class _UILayoutFooterComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _UILayoutFooterComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client=_httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7009/api/Contact");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData=await responseMessage.Content.ReadAsStringAsync();
                var value=JsonConvert.DeserializeObject<List<ResultContactDto>>(jsonData);
                return View(value);
            }
            return View();
        }
    }
}
