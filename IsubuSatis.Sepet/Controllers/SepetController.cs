using IsubuSatis.Sepet.Models;
using IsubuSatis.Sepet.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Schema;

namespace IsubuSatis.Sepet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SepetController : ControllerBase
    {
        private readonly ISepetService _sepetService;
        private readonly IIdentityHelperService _identityHelperService;

        public SepetController(ISepetService sepetService,
            IIdentityHelperService identityHelperService)
        {
            _sepetService = sepetService;
            _identityHelperService = identityHelperService;
        }

        [HttpGet]
        public async Task<SepetDto> GetSepet()
        {
            var userId = _identityHelperService.GetUserId();
            
            if (string.IsNullOrEmpty(userId))
                throw new Exception("Kullanıcı bilgisi hatalı");

            var sepet = await _sepetService.GetSepet(userId);
            return sepet;
        }

        [HttpPost]
        public async Task SepetiKaydet(SepetDto sepetDto)
        {
            var userId = _identityHelperService.GetUserId();

            if (string.IsNullOrEmpty(userId))
                throw new Exception("Kullanıcı bilgisi hatalı");

            sepetDto.UserId = userId;

            await _sepetService.SepetiKaydet(sepetDto);
        }
    }
}
