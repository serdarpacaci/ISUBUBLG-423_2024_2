using IsubuSatis.Sepet.Models;
using System.Text.Json.Serialization;

namespace IsubuSatis.Sepet.Services
{
    public interface ISepetService
    {
        Task<SepetDto> GetSepet(string userId);

        Task SepetiKaydet(SepetDto sepet);

        Task SepetiBosalt(string userId);
    }
}
