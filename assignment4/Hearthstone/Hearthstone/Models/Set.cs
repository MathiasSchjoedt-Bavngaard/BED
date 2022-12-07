﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace Hearthstone.Models
{
    public class Set
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        [JsonPropertyName("collectibleCount")]
        public int CardCount { get; set; }
    }
}
