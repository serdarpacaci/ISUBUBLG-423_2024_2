using IsubuSatis.KatalogService.Dtos;

namespace IsubuSatis.KatalogService.Services
{
    public interface IUrunService
    {
        Task Create(CreateUrunDto input);
        Task Update(UpdateUrunDto input);

        Task<List<UrunDto>> GetUrunler();

    }
}
