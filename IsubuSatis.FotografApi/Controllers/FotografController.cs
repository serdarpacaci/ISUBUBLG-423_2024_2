using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IsubuSatis.FotografApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FotografController : ControllerBase
    {
        private readonly string _fotografKlasorPath;
        private static List<string> _izinVerilenFormatlar = new List<string>
        {
            "image/png"
        };


        public FotografController()
        {
            _fotografKlasorPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwRoot", "images");
        }
        [HttpPost]
        public IActionResult Kaydet(IFormFile formFile)
        {
            if (formFile.Length == 0 || 
                !_izinVerilenFormatlar.Any(x=> x == formFile.ContentType))
                return BadRequest();

            var fileExtension = Path.GetExtension(formFile.FileName);
            var fileName = Path.GetRandomFileName();
            fileName = fileName.Substring(0, fileName.Length - 4) + fileExtension;

            var fotografPath = Path.Combine(_fotografKlasorPath, fileName);

            using var stream = new FileStream(fotografPath, FileMode.Create);
            formFile.CopyTo(stream);
            stream.Close();

            return Ok();

        }
    }
}
