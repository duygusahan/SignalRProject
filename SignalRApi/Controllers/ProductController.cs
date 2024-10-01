using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRProject.BusinessLayer.Abstract;
using SignalRProject.DtoLayer.CategoryDtos;
using SignalRProject.DtoLayer.ProductDtos;
using SignalRProject.EntityLayer.Concrete;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ProductList()
        {
            var value =_productService.TGetListAll();
            return Ok(_mapper.Map<List<ResultProductDto>>(value));
        }
        [HttpPost]
        public IActionResult CreateProduct(CreateProductDto createProductDto)
        {

            var value = _mapper.Map<Product>(createProductDto);
            _productService.TInsert(value);
            return Ok("İşleminiz başarıyla gerçekleşti");
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _productService.TDelete(id);
            return Ok("İşleminiz başarıyla gerçekleşti");
        }

        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductDto updateProductDto) 
        {
           
            var value=_mapper.Map<Product>(updateProductDto);
            _productService.TUpdate(value);
            return Ok("İşleminiz başarıyla gerçekleşti");
        }

        [HttpGet("GetProduct")]
        public IActionResult GetProduct(int id) 
        {
            var value= _productService.TGetById(id);
            return Ok(_mapper.Map<GetProductDto>(value));
        }

        [HttpGet("GetProductsWithCategory")]
        public IActionResult GetProductsWithCategory()
        {
            var values = _productService.TGetProductsWithCategory();
            return Ok(values);
        }

        [HttpGet("ProductCount")]
        public IActionResult ProductCount()
        {
            var values=_productService.TProductCount();
            return Ok(values);
        }
        [HttpGet ("ProductCountByCategoryNameDrink")]
        public IActionResult ProductCountByCategoryNameDrink()
        {
            var value=_productService.TProductCountByCategoryNameDrink();
            return Ok(value);
        }

        [HttpGet("ProductCountByCategoryNameHamburger")]
        public IActionResult ProductCountByCategoryNameHamburger()
        {
            var value=_productService.TProductCountByCategoryNameHamburger();
            return Ok(value);   
        }

        [HttpGet("ProductPriceAvg")]
        public IActionResult ProductPriceAvg()
        {
            var value=_productService.TProductPriceAvg();
            return Ok(value);
        }

        [HttpGet("ProductPriceByMax")]
        public IActionResult ProductPriceByMax()
        {
            var value=_productService.TProductPriceByMax();
            return Ok(value);
        }

        [HttpGet("ProductPriceByMin")]
        public IActionResult ProductPriceByMin()
        {
            var value = _productService.TProductPriceByMin();
            return Ok(value);
        }

        [HttpGet("HamburgerPriceAvg")]
        public IActionResult HamburgerPriceAvg()
        {
            var value=_productService.THamburgerPriceAvg();
            return Ok(value);   
        }
        [HttpGet("Get9Product")]
        public IActionResult Get9Product()
        {
            var value=_productService.TGet9Products();
            return Ok(value);
        }
        [HttpGet("SmokyBBQBurgerPrice")]
        public IActionResult SmokyBBQBurgerPrice()
        {
           var value= _productService.TSmokyBBQBurgerPrice();
            return Ok(value);
        }
        [HttpGet("TotalDrinkPrice")]
        public IActionResult TotalDrinkPrice()
        {
            var value=_productService.TTotalDrinkPrice();
            return Ok(value);
        }
        [HttpGet("TotalSaladPrice")]
        public IActionResult TotalSaladPrice()
        {
            var value=_productService.TTotalSaladPrice();
            return Ok(value);
        }
        [HttpGet("TotalProductPrice")]
        public IActionResult TotalProductPrice()
        {
            var value=_productService.TTotalProductPrice();
            return Ok(value);
        }
    }
}
