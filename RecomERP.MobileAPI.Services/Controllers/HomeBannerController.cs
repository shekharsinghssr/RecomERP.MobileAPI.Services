using Microsoft.AspNetCore.Mvc;
using RecomERP.MobileAPI.Application.IServices;

namespace RecomERP.MobileAPI.ApiServices.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeBannerController : ControllerBase
    {
        private readonly IHomeBannerService _homeBannerService;

        public HomeBannerController(IHomeBannerService homeBannerService)
        {
            _homeBannerService = homeBannerService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllBanners()
        {
            var banners = await _homeBannerService.GetAllBannersAsync();
            return Ok(banners);
        }

        [HttpGet("GetByID/{id}")]
        public async Task<IActionResult> GetBannerByID(int id)
        {
            var banner = await _homeBannerService.GetBannerByIDAsync(id);
            if (banner == null)
                return NotFound($"Banner with ID {id} not found");
            return Ok(banner);
        }
    }
}