using IsubuSatis.KatalogService.Dtos;
using IsubuSatis.KatalogService.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IsubuSatis.KatalogService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class KategoriController : ControllerBase
    {
        private readonly IKategoriService _kategoriService;

        public KategoriController(IKategoriService kategoriService)
        {
            _kategoriService = kategoriService;
        }

        [HttpGet]
        public async Task<List<KategoriDto>> Getkategoriler()
        {
            return await _kategoriService.GetKategoriler();
        }

        [HttpPost]
        public async Task KategoriEkle(CreateorUpdateKategoriDto input)
        {
            await _kategoriService.CreateOrUpdate(input);
        }

        [HttpPut]
        public async Task KategoriGuncelle(CreateorUpdateKategoriDto input)
        {
            await _kategoriService.CreateOrUpdate(input);
        }


        [HttpDelete]
        public async Task KategoriSil(string id)
        {
            await _kategoriService.Sil(id);
        }

    }
}
