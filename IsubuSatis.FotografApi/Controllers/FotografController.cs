using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IsubuSatis.FotografApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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


        [HttpPost]
        public async Task<IActionResult> Kaydet2(IFormFile formFile, CancellationToken token)
        {
            if (formFile.Length == 0 ||
                !_izinVerilenFormatlar.Any(x => x == formFile.ContentType))
                return BadRequest();

            var fileExtension = Path.GetExtension(formFile.FileName);
            var fileName = Path.GetRandomFileName();
            fileName = fileName.Substring(0, fileName.Length - 4) + fileExtension;

            var fotografPath = Path.Combine(_fotografKlasorPath, fileName);

            using var stream = new FileStream(fotografPath, FileMode.Create);
            await formFile.CopyToAsync(stream);
            stream.Close();

            if (token.IsCancellationRequested && System.IO.File.Exists(fotografPath))
            {
                System.IO.File.Delete(fotografPath);
            }

            return Ok(new {FileName = fileName });

        }

        public IActionResult Sil(string fileName)
        {
            var path = Path.Combine(_fotografKlasorPath, fileName);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }

            return Ok();
        }
    }
}
