using IsubuSatis.KatalogService.Dtos;
using IsubuSatis.KatalogService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IsubuSatis.KatalogService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrunController : ControllerBase
    {
        private readonly IUrunService _urunService;

        public UrunController(IUrunService urunService)
        {
            _urunService = urunService;
        }

        [HttpGet]
        public async Task<List<UrunDto>> GetUrunler()
        {
            return await _urunService.GetUrunler();
        }

        [HttpPost]
        public async Task UrunEkle(CreateUrunDto input)
        {
            await _urunService.Create(input);
        }
    }
}
