using IsubuSatis.Sepet.Models;
using IsubuSatis.Sepet.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace IsubuSatis.Sepet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RedisTestController : ControllerBase
    {
        private readonly RedisService redisService;

        public RedisTestController(RedisService redisService)
        {
            this.redisService = redisService;
        }

        [HttpGet]
        public async Task<List<Ders>> GetCacheTest()
        {
            var database =  redisService.GetDatabase();
            var dersler = await database.StringGetAsync("dersler");
           
            if (dersler.HasValue)
            {
                var result = JsonSerializer.Deserialize<List<Ders>>(dersler);
                
                return result;
            }

            var dbDersler = await GetDersler();
            var dbDerslerJson = JsonSerializer.Serialize(dbDersler);
            await database.StringSetAsync("dersler", dbDerslerJson);

            return dbDersler;
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
