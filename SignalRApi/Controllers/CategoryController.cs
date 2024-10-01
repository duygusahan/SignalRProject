using AutoMapper;
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
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult CategoryList() 
        {
            var value=_categoryService.TGetListAll();
            return Ok(_mapper.Map<List<ResultCategoryDto>>(value));

        }
        [HttpPost]
        public IActionResult CreateCategory(CreateCategoryDto createCategoryDto)
        {
            var value=_mapper.Map<Category>(createCategoryDto);
            _categoryService.TInsert(value);
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
            var value = _mapper.Map<Category>(updateCategoryDto);
            _categoryService.TUpdate(value);
            return Ok("İşleminiz başarılı bir şekilde gerçekleşti");
        }
        [HttpGet("GetCategory")]
        public IActionResult GetCategory(int id) 
        {
            var value= _categoryService.TGetById(id);
            return Ok(_mapper.Map<GetCategoryDto>(value));
        }
        [HttpGet("CategoryCount")]
        public IActionResult CategoryCount()
        {
            var value = _categoryService.TCategoryCount();
            return Ok(value);
        }
        [HttpGet ("ActiveCategoryCount")]
        public IActionResult ActiveCategoryCount()
        {
            var value=_categoryService.TActiveCategoryCount();
            return Ok(value);   
        }
        [HttpGet("PassiveCategoryCount")]
        public IActionResult PassiveCategoryCount()
        {
            var value=_categoryService.TPassiveCategoryCount();
            return Ok(value);
        }
    }
}
