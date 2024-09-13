using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRProject.BusinessLayer.Abstract;
using SignalRProject.DtoLayer.CategoryDtos;
using SignalRProject.EntityLayer.Concrete;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet]
        public IActionResult CategoryList() 
        {
            var value=_categoryService.TGetListAll();
            return Ok(value);

        }
        [HttpPost]
        public IActionResult CreateCategory(CreateCategoryDto createCategoryDto)
        {
            Category category = new Category()
            {
                CategoryName = createCategoryDto.CategoryName,
                Status = createCategoryDto.Status,
            };
            _categoryService.TInsert(category);
            return Ok("İşleminiz başarılı bir şekilde gerçekleşti");
        }
        [HttpDelete]
        public IActionResult DeleteCategory(int id) 
        {
            _categoryService.TDelete(id);
            return Ok("İşleminiz başarılı bir şekilde gerçekleşti");
        }
        [HttpPut]
        public IActionResult UpdateCategory(UpdateCategoryDto updateCategoryDto) 
        {
            Category category = new Category()
            {
                CategoryId = updateCategoryDto.CategoryId,
                Status = updateCategoryDto.Status,
                CategoryName=updateCategoryDto.CategoryName,
            };

            _categoryService.TUpdate(category);
            return Ok("İşleminiz başarılı bir şekilde gerçekleşti");
        }
        [HttpGet("GetCategory")]
        public IActionResult GetCategory(int id) 
        {
            var value= _categoryService.TGetById(id);
            return Ok(value);
        }
    }
}
