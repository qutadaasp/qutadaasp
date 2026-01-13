using KAShop2.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KAShop2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        IOS _IOSPlatform;
        public PlatformsController(IOS IOSPlatform) {
            _IOSPlatform = IOSPlatform;

        }
       

        [HttpGet]
        public IActionResult get()
        {
            return Ok(_IOSPlatform.Run());
        }
    }
}
