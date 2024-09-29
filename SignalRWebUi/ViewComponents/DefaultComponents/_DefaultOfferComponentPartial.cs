﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRProject.DtoLayer.DiscountDtos;

namespace SignalRWebUi.ViewComponents.DefaultComponents
{
    public class _DefaultOfferComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultOfferComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client =_httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7009/api/Discount/GetDiscountByStatusTrue");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData=await responseMessage.Content.ReadAsStringAsync();
                var value=JsonConvert.DeserializeObject<List<ResultDiscountDto>>(jsonData);
                return View(value);
            }
            return View();
        }
    }
}
