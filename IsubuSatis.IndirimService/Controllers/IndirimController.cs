using IsubuSatis.IndirimService.Models;
using IsubuSatis.IndirimService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IsubuSatis.IndirimService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IndirimController : ControllerBase
    {
        private readonly IIndirimService _indirimService;

        public IndirimController(IIndirimService indirimService)
        {
            _indirimService = indirimService;
        }

        [HttpGet]
        public async Task<List<Indirim>> GetAll()
        {
            return await _indirimService.GetAllIndirim();
        }

        [HttpPost]
        public async Task Kaydet( Indirim indirim)
        {
            await _indirimService.Kaydet(indirim);
        }
    }
}
