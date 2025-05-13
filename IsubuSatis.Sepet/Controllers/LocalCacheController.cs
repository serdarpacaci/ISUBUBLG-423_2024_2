using IsubuSatis.Sepet.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace IsubuSatis.Sepet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocalCacheController : ControllerBase
    {
        private readonly IMemoryCache _memoryCache;

        public LocalCacheController(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        [HttpGet]
        public async Task<List<Ders>> GetCacheTest()
        {
           var sonuc = await _memoryCache.GetOrCreateAsync("dersler", async x =>
            {
                //x.AbsoluteExpiration = DateTime.Now.AddSeconds(60);
                x.SlidingExpiration = TimeSpan.FromSeconds(15);

                var dersler = await GetDersler();

                return dersler;
            });

            return sonuc;
        }

        private async Task<List<Ders>> GetDersler()
        {
            await Task.Delay(5000);

            return new List<Ders> { new Ders{ Id= 1, DersAdi = "C#"},
                new Ders{ Id= 2, DersAdi = "Sql"},
                new Ders{ Id= 3, DersAdi = "Web"},
                new Ders{ Id= 4, DersAdi = "Veri tabanı"}
            };
        }
    }
}
