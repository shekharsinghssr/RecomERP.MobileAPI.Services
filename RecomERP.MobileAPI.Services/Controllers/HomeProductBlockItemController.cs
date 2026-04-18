using Microsoft.AspNetCore.Mvc;
using RecomERP.MobileAPI.Application.IServices;

namespace RecomERP.MobileAPI.ApiServices.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeProductBlockItemController : ControllerBase
    {
        private readonly IHomeProductBlockItemService _homeProductBlockItemService;

        public HomeProductBlockItemController(IHomeProductBlockItemService homeProductBlockItemService)
        {
            _homeProductBlockItemService = homeProductBlockItemService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllHomeProductBlockItems()
        {
            var items = await _homeProductBlockItemService.GetAllHomeProductBlockItemsAsync();
            return Ok(items);
        }

        //[HttpGet("GetByID/{id}")]
        //public async Task<IActionResult> GetHomeProductBlockItemByID(int id)
        //{
        //    var item = await _homeProductBlockItemService.GetHomeProductBlockItemByIDAsync(id);
        //    if (item == null)
        //        return NotFound($"HomeProductBlockItem with ID {id} not found");
        //    return Ok(item);
        //}


        [HttpGet("GetByProductBlockId/{productBlockId}")]
        public async Task<IActionResult> GetItemsByProductBlockId(int productBlockId)
        {
            var items = await _homeProductBlockItemService.GetItemsByProductBlockIdAsync(productBlockId);
            return Ok(items);
        }
    }
}