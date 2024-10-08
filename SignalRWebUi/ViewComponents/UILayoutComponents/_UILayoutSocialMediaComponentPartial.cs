﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRProject.DtoLayer.SocialMediaDtos;

namespace SignalRWebUi.ViewComponents.UILayoutComponents
{
    public class _UILayoutSocialMediaComponentPartial:ViewComponent
    {
       
        
            private readonly IHttpClientFactory _httpClientFactory;

        public _UILayoutSocialMediaComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7009/api/SocialMedia");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<ResultSocialMediaDto>>(jsonData);
                return View(value);
            }
            return View();
        }
    }
    
}
