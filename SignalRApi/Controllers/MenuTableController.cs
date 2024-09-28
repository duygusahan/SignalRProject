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

        public MenuTableController(IMenuTableService menuTableService)
        {
            _menuTableService = menuTableService;
        }
        [HttpGet]
        public IActionResult MenuTableList()
        {
            var value = _menuTableService.TGetListAll();
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateMenuTable(CreateMenuTableDto createMenuTableDto)
        {
            MenuTable menuTable = new MenuTable()
            {
                Name = createMenuTableDto.Name,
                status = false,
            };
            _menuTableService.TInsert(menuTable);
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
            MenuTable menuTable = new MenuTable()
            {
                MenuTableID = updateMenuTableDto.MenuTableID,
                Name = updateMenuTableDto.Name,
                status = false,

            };
            _menuTableService.TUpdate(menuTable);
            return Ok("Masa basarılı bir şekilde güncellendi");
        }

        [HttpGet("GetMenuTable")]
        public IActionResult GetMenuTable(int id)
        {
            var value=_menuTableService.TGetById(id);
            return Ok(value);
        }


        [HttpGet("MenuTableCount")]
        public IActionResult MenuTableCount()
        {
            var value = _menuTableService.TMenuTableCount();
            return Ok(value);
        }
    }
}
