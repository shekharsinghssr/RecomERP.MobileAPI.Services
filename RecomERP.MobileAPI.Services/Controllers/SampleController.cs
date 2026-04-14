using Microsoft.AspNetCore.Mvc;
namespace RecomERP.MobileAPI.ApiServices.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SampleController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get() => Ok("Sample API Response");
    }
}
