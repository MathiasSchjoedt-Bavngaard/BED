using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Hearthstone.Models
{
    public class Class
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
