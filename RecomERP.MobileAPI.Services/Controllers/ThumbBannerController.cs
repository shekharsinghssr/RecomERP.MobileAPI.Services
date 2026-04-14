using Microsoft.AspNetCore.Mvc;
using RecomERP.MobileAPI.Application.IServices;

namespace RecomERP.MobileAPI.ApiServices.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ThumbBannerController : ControllerBase
    {
        private readonly IThumbBannerService _thumbBannerService;

        public ThumbBannerController(IThumbBannerService thumbBannerService)
        {
            _thumbBannerService = thumbBannerService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllThumbBanners()
        {
            var banners = await _thumbBannerService.GetAllThumbBannersAsync();
            return Ok(banners);
        }

        [HttpGet("GetByID/{id}")]
        public async Task<IActionResult> GetThumbBannerByID(int id)
        {
            var banner = await _thumbBannerService.GetThumbBannerByIDAsync(id);
            if (banner == null)
                return NotFound($"ThumbBanner with ID {id} not found");
            return Ok(banner);
        }
    }
}