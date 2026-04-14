using Microsoft.AspNetCore.Mvc;
using RecomERP.MobileAPI.Application.IServices;

namespace RecomERP.MobileAPI.ApiServices.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeProductBlockController : ControllerBase
    {
        private readonly IHomeProductBlockService _homeProductBlockService;

        public HomeProductBlockController(IHomeProductBlockService homeProductBlockService)
        {
            _homeProductBlockService = homeProductBlockService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllHomeProductBlocks()
        {
            var blocks = await _homeProductBlockService.GetAllHomeProductBlocksAsync();
            return Ok(blocks);
        }

        [HttpGet("GetByID/{id}")]
        public async Task<IActionResult> GetHomeProductBlockByID(int id)
        {
            var block = await _homeProductBlockService.GetHomeProductBlockByIDAsync(id);
            if (block == null)
                return NotFound($"HomeProductBlock with ID {id} not found");
            return Ok(block);
        }
    }
}