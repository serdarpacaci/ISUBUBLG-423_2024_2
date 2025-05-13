namespace IsubuSatis.IndirimService.Models
{
    public class Indirim
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int Oran { get; set; }
        public string Kod { get; set; }
        public bool IsActive { get; set; }
        public DateTime OlusturulmaTarihi { get; set; }
    }
}
