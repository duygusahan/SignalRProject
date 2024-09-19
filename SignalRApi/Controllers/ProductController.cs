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
        private readonly IMapper mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult ProductList()
        {
            var value = mapper.Map<List<ResultProductDto>>(_productService.TGetListAll());
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateProduct(CreateProductDto createProductDto)
        {
          
            _productService.TInsert(new Product()
            {
                ProductName= createProductDto.ProductName,
                Description= createProductDto.Description,
                ImageUrl= createProductDto.ImageUrl,
                Price= createProductDto.Price,
                Status= createProductDto.Status,
               CategoryId=createProductDto.CategoryId, 
            });
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
           
            _productService.TUpdate(new Product()
            {
                Status = updateProductDto.Status,
                ProductName= updateProductDto.ProductName,
                Description= updateProductDto.Description,
                ImageUrl= updateProductDto.ImageUrl,
                Price= updateProductDto.Price,
                ProductId= updateProductDto.ProductId,
                CategoryId = updateProductDto.CategoryId,
            });
            return Ok("İşleminiz başarıyla gerçekleşti");
        }

        [HttpGet("GetProduct")]
        public IActionResult GetProduct(int id) 
        {
            var value= _productService.TGetById(id);
            return Ok(value);
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
    }
}
