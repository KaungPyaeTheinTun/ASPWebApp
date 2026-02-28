using ASPWebApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ASPWebApp.Controllers
{
    public class MediaController : Controller
    {
        private readonly IMediaService _mediaService;

        public MediaController(IMediaService mediaService)
        {
            _mediaService = mediaService;
        }

        [HttpPost]
        public IActionResult Upload(IFormFile file)
        {
            var media = _mediaService.UploadFile(file);

            if (media == null)
                return BadRequest("Upload failed");

            return Json(media);
        }

        [HttpPost]
        public IActionResult Delete(string fileName)
        {
            _mediaService.DeleteFile(fileName);
            return Ok();
        }
    }
}