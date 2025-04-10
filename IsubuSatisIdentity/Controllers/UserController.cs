using IsubuSatisIdentity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace IsubuSatisIdentity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> KullaniciKayit(KullaniciKayitDto input)
        {
            var eklenecekUser = new ApplicationUser
            {
                Email = input.EPosta,
                UserName = input.KullaniciAdi,
            };

            var sonuc = await _userManager.CreateAsync(eklenecekUser, input.Sifre);
            if (!sonuc.Succeeded)
            {
                return BadRequest(sonuc.Errors.Select(x => x.Description));
            }

            return Ok();

        }
    }
}
