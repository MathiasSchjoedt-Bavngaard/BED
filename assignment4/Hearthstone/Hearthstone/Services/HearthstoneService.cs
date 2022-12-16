﻿using Hearthstone.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Text.Json;
using System.Xml.Linq;

namespace Hearthstone.Services
{
    public class HearthstoneServiceSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
    
    public class HearthstoneService
    {
        public readonly IMongoCollection<Card> Cards;
        public readonly IMongoCollection<CardType> CardTypes;
        public readonly IMongoCollection<Class> Classes;
        public readonly IMongoCollection<Rarity> Rarities;
        public readonly IMongoCollection<Set> Sets;

        public HearthstoneService(HearthstoneServiceSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            Cards = database.GetCollection<Card>("cards");
            CardTypes = database.GetCollection<CardType>("CardTypes");
            Classes = database.GetCollection<Class>("Classes");
            Rarities = database.GetCollection<Rarity>("Rarities");
            Sets = database.GetCollection<Set>("Sets");
            //var FileList 

            //if (client.GetDatabase(settings.DatabaseName).ListCollections().ToList().Count == 0)
            //{

            //    var collection = database.GetCollection<Card>("cards");
            //    for

            //    foreach (var path in new[] { "lea.json", "arn.json", "atq.json", "leg.json" })
            //    {
            //        using (var file = new StreamReader(path))
            //        {
            //            var cards = JsonSerializer.Deserialize<List<Card>>(file.ReadToEnd(), new JsonSerializerOptions
            //            {
            //                PropertyNameCaseInsensitive = true
            //            });
            //            collection.InsertMany(cards);
            //        }
            //    }
            //}
        }
        public void SeedDataBase()
        {
            
        }
        public FilterDefinition<Card> CreateCardFilter(int setid, string artist, int classid, int rarityid)
        {
            var builder = Builders<Card>.Filter;
            var filter = builder.Empty;


            if (setid != 0)
            {
                filter &= builder.Eq(x => x.cardSetId, setid);
                
            }
            if (artist != null)
            {
                filter &= builder.Regex(x => x.artistName, new BsonRegularExpression($"/{artist}/i"));

            }
            if (classid != 0)
            {
                filter &= builder.Eq(x => x.ClassId, classid);
                
            }
            if (rarityid != 0)
            {
                filter &= builder.Eq(x => x.RarityId, rarityid);

            }
            return filter;
        }
    }
}
