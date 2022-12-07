using Hearthstone.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Hearthstone.Services
{
    public class HearthstoneServiceSettings
    {
        public string ConnectionString;
        public string DatabaseName;
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

            Cards = database.GetCollection<Card>("Cards");
            CardTypes = database.GetCollection<CardType>("CardTypes");
            Classes = database.GetCollection<Class>("Classes");
            Rarities = database.GetCollection<Rarity>("Rarities");
            Sets = database.GetCollection<Set>("Sets");
        }
    }
}
