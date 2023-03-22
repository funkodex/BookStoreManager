using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagerBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("allowedOrigin")]
    public class ImagesController: ControllerBase
    {

        [HttpPost("{resourceType}")]
        public IActionResult upload(string resourceType, IFormFile image)
        {
            return Ok();
        }
    }
}
