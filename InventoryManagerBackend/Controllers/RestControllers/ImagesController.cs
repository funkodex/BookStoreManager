using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InventoryManagerBackend.Controllers.RestControllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    [EnableCors("allowedOrigin")]
    public class ImagesController : ControllerBase
    {
        private readonly IWebHostEnvironment env;

        public ImagesController(IWebHostEnvironment env)
        {
            this.env = env;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> OnPostUploadAsync(List<IFormFile> files)
        {
            long size = files.Sum(f => f.Length);
            var newFileName = "";

            foreach (var formFile in files)
            {
                
                if (formFile.Length > 0)
                {
                    var fileName = formFile.FileName.Split('.').First();
                    var fileExt = formFile.FileName.Split('.').Last();
                    if (!Directory.Exists(env.ContentRootPath + "images"))
                    {
                        Directory.CreateDirectory(env.ContentRootPath + "images");
                    }
                    newFileName = $"{fileName}-{Guid.NewGuid()}.{fileExt}";
                    var filePath = Path.Combine(env.ContentRootPath+$"images\\{newFileName}");

                    using (var stream = System.IO.File.Create(filePath))
                    {
                        await formFile.CopyToAsync(stream);
                    }
                }
            }

            // Process uploaded files
            // Don't rely on or trust the FileName property without validation.

            return Ok(new { count = files.Count, size ,url = newFileName });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFileById(String id)
        {
            var path = Path.Combine(env.ContentRootPath + $"images\\{id}");


            if (System.IO.File.Exists(path))
            {
                return File(System.IO.File.OpenRead(path), "application/octet-stream", Path.GetFileName(path));
            }
            return NotFound();
        }
    }
}
