using AutoMapper;
using IsubuSatis.KatalogService.Dtos;
using IsubuSatis.KatalogService.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Net.WebSockets;

namespace IsubuSatis.KatalogService.Services
{
    public class UrunService : IUrunService
    {
        private readonly IMongoCollection<Urun> _urunCollection;
        private readonly IMongoCollection<Kategori> _kategoriCollection;

        private readonly MongoDbSettings _databaseSettings;

        private readonly IMapper _mapper;

        public UrunService(IOptions<MongoDbSettings> option, 
            IMapper mapper)
        {
            _databaseSettings = option.Value;

            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.Database);

            _urunCollection = database
                .GetCollection<Urun>(MongoDbTables.UrunTableName);


            _kategoriCollection = database.GetCollection<Kategori>(MongoDbTables.KategoriTableName);

            _mapper = mapper;
        }

        public async Task Create(CreateUrunDto input)
        {
            var eklenecekUrun = _mapper.Map<Urun>(input);

            await _urunCollection.InsertOneAsync(eklenecekUrun);
        }

        public async Task<List<UrunDto>> GetUrunler()
        {
            var urunler = await _urunCollection.AsQueryable()
                .ToListAsync();

            var kategoriIdList = urunler
                .Select(x => x.KategoriId)
                .Distinct()
                .ToList();

            var kategoriList = await _kategoriCollection.AsQueryable()
                .Where(x => kategoriIdList.Contains(x.Id))
                .ToListAsync();

            var result = _mapper.Map<List<UrunDto>>(urunler);

            //result.ForEach(x=>
            //{
            //    x.KategoriAdi = kate
            //})

            return result;
        }

        public async Task Update(UpdateUrunDto input)
        {
            var urun = await _urunCollection.AsQueryable().
                Where(x => x.Id == input.Id)
                .FirstOrDefaultAsync();

            if (urun is null)
                throw new Exception("");

            _mapper.Map(input, urun);

            await _urunCollection
                .ReplaceOneAsync(Builders<Urun>.Filter.Eq(x => x.Id, input.Id), urun);
        }
    }
}
