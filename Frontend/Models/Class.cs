using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Radiologi___Frontend___Maui.Models
{
    public class Class
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string ClassName { get; set; }
        public string ClassCode { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]
        public string TeacherId { get; set; }
    }
}
