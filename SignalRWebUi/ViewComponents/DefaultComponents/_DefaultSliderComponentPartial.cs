using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRProject.DtoLayer.FeatureDtos;

namespace SignalRWebUi.ViewComponents.DefaultComponents
{
	public class _DefaultSliderComponentPartial:ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultSliderComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
		{
			var client=_httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7009/api/Feature");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData= await responseMessage.Content.ReadAsStringAsync();
				var value=JsonConvert.DeserializeObject<List<ResultFeatureDto>>(jsonData);
				return View(value);
			}
			return View();
		}
	}
}
