﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRProject.DtoLayer.MessageDtos;
using System.Text;

namespace SignalRWebUi.Controllers
{
    public class DefaultController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DefaultController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult SendMessage()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(CreateMessageDto createMessageDto)
        {
            var client=_httpClientFactory.CreateClient();
            var jsonData=JsonConvert.SerializeObject(createMessageDto);
            StringContent stringContent = new StringContent(jsonData , Encoding.UTF8 , "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7009/api/Message", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
