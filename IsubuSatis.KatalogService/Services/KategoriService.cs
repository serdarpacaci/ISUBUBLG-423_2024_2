using AutoMapper;
using IsubuSatis.KatalogService.Dtos;
using IsubuSatis.KatalogService.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Linq;

namespace IsubuSatis.KatalogService.Services
{
    public class KategoriService : IKategoriService
    {
        private readonly IMongoCollection<Kategori> _kategoriCollection;

        private readonly MongoDbSettings _databaseSettings;

        private readonly IMapper _mapper;
        public KategoriService(IOptions<MongoDbSettings> option, 
            IMapper mapper)
        {
            _databaseSettings = option.Value;

            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.Database);

            _kategoriCollection = database
                .GetCollection<Kategori>(MongoDbTables.KategoriTableName);
            
            _mapper = mapper;
        }

        public async Task CreateOrUpdate(CreateorUpdateKategoriDto input)
        {
            if (input.Id is null)
            {
                await Create(input);
            }
            else
            {
                await Update(input);
            }
        }

        private async Task Update(CreateorUpdateKategoriDto input)
        {
            var kategori = await _kategoriCollection.AsQueryable().
                Where(x => x.Id == input.Id)
                .FirstOrDefaultAsync();

            if (kategori is null)
                throw new Exception("");

            //kategori.Ad = input.Ad;

            _mapper.Map(input, kategori);

            await _kategoriCollection
                .ReplaceOneAsync(Builders<Kategori>.Filter.Eq(x => x.Id, input.Id), kategori);
        }

        private async Task Create(CreateorUpdateKategoriDto input)
        {
            //var eklenecekKategori = new Kategori
            //{
            //    Ad = input.Ad
            //};

            var eklenecekKategori = _mapper.Map<Kategori>(input);

            await _kategoriCollection.InsertOneAsync(eklenecekKategori);
        }

        public async Task<List<KategoriDto>> GetKategoriler()
        {
            var kategoriler = await _kategoriCollection.AsQueryable()
                .ToListAsync();

            return _mapper.Map<List<KategoriDto>>(kategoriler);
           
            //return kategoriler.Select(x => new KategoriDto
            //{
            //    Id = x.Id,
            //    Ad = x.Ad
            //}).ToList();

        }

        public async Task Sil(string id)
        {
            await _kategoriCollection.DeleteOneAsync(Builders<Kategori>.Filter.Eq(x => x.Id, id));
        }
    }

}
