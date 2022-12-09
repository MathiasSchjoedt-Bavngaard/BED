using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Hearthstone.Models
{
    public class Rarity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? _id { get; set; }
        public string Name { get; set; }

        public int Id { get; set; }
    }
}
