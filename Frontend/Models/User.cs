﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Diagnostics.CodeAnalysis;

namespace Radiologi___Frontend___Maui.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int IsTeacher { get; set; }
        [AllowNull]
        [BsonRepresentation(BsonType.ObjectId)]
        public List<string> ClassIds { get; set; } = new List<string>();
    }
}
