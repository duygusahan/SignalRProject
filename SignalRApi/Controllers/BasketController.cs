using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignalRApi.Model;
using SignalRProject.BusinessLayer.Abstract;
using SignalRProject.DataAccessLayer.Context;
using SignalRProject.DtoLayer.BasketDto;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;

        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }

        [HttpGet]
        public IActionResult GetBasketByMenuTableNumber(int id)
        {
            var values = _basketService.TGetBasketByMenuTableNumber(id);
            return Ok(values);
        }

        [HttpGet("BasketListByMenuTableWithProductName")]
        public IActionResult BasketListByMenuTableWithProductName(int id)
        {
            using var context = new SignalRContext();
            var values = context.Baskets.Include(x => x.Product).Where(y => y.MenuTableID == id).Select(z => new ResultBasketListWithProducts
            {
                BasketID = z.BasketId,
                Count = z.Count,
                MenuTableID = z.MenuTableID,
                Price = z.Price,
                ProductID = z.ProductId,
                TotalPrice = z.TotalPrice,
                ProductName = z.Product.ProductName
            }).ToList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateBasket(CreateBasketDto createBasketDto)
        {
            using var context = new SignalRContext();
            _basketService.TInsert(new SignalRProject.EntityLayer.Concrete.Basket()
            {
                ProductId = createBasketDto.ProductID,
                Count = 1,
                
                Price = context.Products.Where(x => x.ProductId==createBasketDto.ProductID).Select(y => y.Price).FirstOrDefault(),
                TotalPrice=0
            });
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteBasket(int id)
        {
            
            _basketService.TDelete(id);
            return Ok("Sepetteki Seçilen Ürün Silindi");
        }
    }
}
