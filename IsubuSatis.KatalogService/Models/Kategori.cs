﻿using MongoDB.Bson.Serialization.Attributes;

namespace IsubuSatis.KatalogService.Models
{
    public class Kategori
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }


        public string Ad { get; set; }

    }
}
