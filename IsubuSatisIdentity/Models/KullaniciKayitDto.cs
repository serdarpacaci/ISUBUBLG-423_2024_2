using System.ComponentModel.DataAnnotations;

namespace IsubuSatisIdentity.Models
{
    public class KullaniciKayitDto
    {
        [Required]
        public string KullaniciAdi { get; set; }
        [Required]
        public string EPosta { get; set; }
        [Required]
        public string Sifre { get; set; }
    }
}
