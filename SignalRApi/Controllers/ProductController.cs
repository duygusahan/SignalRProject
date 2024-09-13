using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRProject.BusinessLayer.Abstract;
using SignalRProject.DtoLayer.ProductDtos;
using SignalRProject.EntityLayer.Concrete;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult ProductList()
        {
            var value = _productService.TGetListAll();
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateProduct(CreateProductDto createProductDto)
        {
            Product product= new Product()
            {
                Description = createProductDto.Description,
                ImageUrl = createProductDto.ImageUrl,
                Price = createProductDto.Price,
                ProductName = createProductDto.ProductName,
                Status = createProductDto.Status
            };
            _productService.TInsert(product);
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
            Product product = new Product()
            {
                Status = updateProductDto.Status,
                ProductName= updateProductDto.ProductName,
                Description = updateProductDto.Description, 
                ImageUrl = updateProductDto.ImageUrl,
                Price= updateProductDto.Price,
                ProductId= updateProductDto.ProductId   
            };
            _productService.TUpdate(product);
            return Ok("İşleminiz başarıyla gerçekleşti");
        }

        [HttpGet("GetProduct")]
        public IActionResult GetProduct(int id) 
        {
            var value= _productService.TGetById(id);
            return Ok(value);
        }
    }
}
