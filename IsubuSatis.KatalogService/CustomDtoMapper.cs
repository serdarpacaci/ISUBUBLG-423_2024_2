using AutoMapper;
using IsubuSatis.KatalogService.Dtos;
using IsubuSatis.KatalogService.Models;

namespace IsubuSatis.KatalogService
{
    public class CustomDtoMapper : Profile
    {
        public CustomDtoMapper()
        {
            CreateMap<Kategori, CreateorUpdateKategoriDto>().ReverseMap();
            CreateMap<Kategori, KategoriDto>().ReverseMap();


            CreateMap<Urun, CreateUrunDto>().ReverseMap();
            CreateMap<Urun, UpdateUrunDto>().ReverseMap();
            CreateMap<Urun, UrunDto>().ReverseMap();
            

        }
    }
}
