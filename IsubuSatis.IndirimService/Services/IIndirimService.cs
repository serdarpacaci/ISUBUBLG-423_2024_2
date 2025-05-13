using Dapper;
using IsubuSatis.IndirimService.Models;
using Npgsql;
using System.Data;

namespace IsubuSatis.IndirimService.Services
{
    public interface IIndirimService
    {
        Task<List<Indirim>> GetAllIndirim();
        Task<Indirim> GetById(int id);
        Task Kaydet(Indirim indirim);
        Task Guncelle(Indirim indirim);
        Task Sil(int id);
    }


    public class MyIndirimService : IIndirimService
    {
        private readonly IDbConnection dbConnection;
        public MyIndirimService(IConfiguration configuration)
        {
            var constr = configuration.GetConnectionString("Default");
            dbConnection = new NpgsqlConnection(constr);
        }
        public async Task<List<Indirim>> GetAllIndirim()
        {
            var sonuc = await dbConnection.QueryAsync<Indirim>("select * from indirim");

            return sonuc.ToList();
        }

        public async Task<Indirim> GetById(int id)
        {
            var sonuc = await dbConnection
                .QueryAsync<Indirim>("select * from indirim where id=@id",
                new
                {
                    Id = id
                });

            return sonuc.FirstOrDefault();
        }

        public async Task Guncelle(Indirim indirim)
        {
            var sonuc = await dbConnection
                .ExecuteAsync("update indirim set UserId=@userId, Oran=@oran, Kod=@kod, IsActive=@isActive",
                indirim);
        }

        public async Task Kaydet(Indirim indirim)
        {
            var sonuc = await dbConnection
                .ExecuteAsync("insert into indirim (UserId,Oran,Kod,IsActive) values (@userId,@oran,@kod,@isActive)",
                indirim);
        }

        public async Task Sil(int id)
        {
            var sonuc = await dbConnection
                   .ExecuteAsync("delete from indirim where id=@id",
                   new
                   {
                       Id = id
                   });
        }
    }
}
