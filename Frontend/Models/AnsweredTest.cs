using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Radiologi___Frontend___Maui.Models
{
    public class AnsweredTest
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public List<Question> Questions { get; set; } = new List<Question>();
        [BsonRepresentation(BsonType.ObjectId)]
        public string UserId { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]
        public string TestId { get; set; }
        public int Score { get; set; }
    }
}
