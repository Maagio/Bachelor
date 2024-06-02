using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Radiologi___Backend.Models
{
    public class Questionare
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public List<Question> Questions { get; set; } = new List<Question>();
        [BsonRepresentation(BsonType.ObjectId)]
        public string TeacherId { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]
        public string ClassId { get; set; }
    }
}
