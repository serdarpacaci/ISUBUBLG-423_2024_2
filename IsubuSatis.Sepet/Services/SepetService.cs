﻿using IsubuSatis.Sepet.Models;
using StackExchange.Redis;
using System.Text.Json;

namespace IsubuSatis.Sepet.Services
{
    public class SepetService : ISepetService
    {
        private readonly RedisService _redisService;
        private readonly IDatabase _database;


        public SepetService(RedisService redisService)
        {
            _redisService = redisService;
            _database = _redisService.GetDatabase();
        }

        public async Task<SepetDto> GetSepet(string userId)
        {
            var sepet = await _database.StringGetAsync(userId);
            if (sepet.HasValue)
                return JsonSerializer.Deserialize<SepetDto>(sepet);

            return new SepetDto
            {
                UserId = userId
            };
        }

        public async Task SepetiBosalt(string userId)
        {
            await  _database.StringGetDeleteAsync(userId);
        }

        public async Task SepetiKaydet(SepetDto sepet)
        {
            var sepetJson = JsonSerializer.Serialize(sepet);
            await _database.StringSetAsync(sepet.UserId, sepetJson);
        }
    }
}
