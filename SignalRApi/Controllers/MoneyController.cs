using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRProject.BusinessLayer.Abstract;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoneyController : ControllerBase
    {
        private readonly IMoneyCaseService _moneyCaseService;

        public MoneyController(IMoneyCaseService moneyCaseService)
        {
            _moneyCaseService = moneyCaseService;
        }

        [HttpGet]
        public IActionResult TotalMoneyCase()
        {
            var value=_moneyCaseService.TTotalMoneyCase();
            return Ok(value);
        }
    }
}
