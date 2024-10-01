using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRProject.BusinessLayer.Abstract;
using SignalRProject.DtoLayer.MenuTableDtos;
using SignalRProject.EntityLayer.Concrete;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuTableController : ControllerBase
    {
        private readonly IMenuTableService _menuTableService;
        private readonly IMapper _mapper;

        public MenuTableController(IMenuTableService menuTableService, IMapper mapper)
        {
            _menuTableService = menuTableService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult MenuTableList()
        {
            var value = _menuTableService.TGetListAll();
            return Ok(_mapper.Map<List<ResultMenuTableDto>>(value));
        }
        [HttpPost]
        public IActionResult CreateMenuTable(CreateMenuTableDto createMenuTableDto)
        {
            var value=_mapper.Map<MenuTable>(createMenuTableDto);
            _menuTableService.TInsert(value);
            return Ok("Yeni masa basarılı bir şekilde eklendi");
        }
        [HttpDelete]
        public IActionResult DeleteMenuTable(int id)
        {
            _menuTableService.TDelete(id);
            return Ok("Masa Silindi");
        }
        [HttpPut]
        public IActionResult UpdateMenuTable(UpdateMenuTableDto updateMenuTableDto)
        {
            var value=_mapper.Map<MenuTable>(updateMenuTableDto);
            _menuTableService.TUpdate(value);
            return Ok("Masa basarılı bir şekilde güncellendi");
        }

        [HttpGet("GetMenuTable")]
        public IActionResult GetMenuTable(int id)
        {
            var value=_menuTableService.TGetById(id);
            return Ok(_mapper.Map<GetEMenuTableDto>(value));
        }


        [HttpGet("MenuTableCount")]
        public IActionResult MenuTableCount()
        {
            var value = _menuTableService.TMenuTableCount();
            return Ok(value);
        }
    }
}
