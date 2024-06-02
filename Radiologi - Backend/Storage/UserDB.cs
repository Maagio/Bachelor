using System.Text.Json;
using MongoDB.Driver;
using MongoDB.Bson;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using MongoDB.Bson.Serialization;
using Radiologi___Backend.Models;

namespace Radiologi___Backend.Storage
{
    public class UserDB : IUserDB
    {
        const string connectionUri = "mongodb+srv://jmuncknielsen:KhLaePLs90UMJKDR@radiolgi.ffbz3p4.mongodb.net/?retryWrites=true&w=majority&appName=Radiolgi";
        MongoClient client;
        IMongoCollection<User> userCollection;
        public UserDB()
        {
            var settings = MongoClientSettings.FromConnectionString(connectionUri);
            // Set the ServerApi field of the settings object to set the version of the Stable API on the client
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            // Create a new client and connect to the server
            client = new MongoClient(settings);

            userCollection = client.GetDatabase("Radiologi").GetCollection<User>("Users");
        }
        public IEnumerable<User> GetUsers()
        {
            ProjectionDefinition<User> projection = Builders<User>.Projection
                .Include(u => u.Name)
                .Include(u => u.Email);

            List<User> users = userCollection
                .Find(new BsonDocument())
                .Project<User>(projection)
                .ToList();

            return users;
        }
        public void CreateUser(User user)
        {
            userCollection.InsertOne(user);
        }
        public User FindUser(User user)
        {
            var filter = Builders<User>.Filter.And(
                Builders<User>.Filter.Eq(u => u.Email, user.Email),
                Builders<User>.Filter.Eq(u => u.Password, user.Password)
                );

            User foundUser = userCollection
                .Find(filter)
                .FirstOrDefault();

            return foundUser;
        }

        public User FindUserById(string Id)
        {
            var filter = Builders<User>.Filter.And(
                Builders<User>.Filter.Eq(u => u.Id, Id)
                );

            User foundUser = userCollection
                .Find(filter)
                .FirstOrDefault();

            return foundUser;
        }

        public List<string> GetClassesByUserId(string userId)
        {
            var filter = Builders<User>.Filter.And(
                Builders<User>.Filter.Eq(u => u.Id, userId)
                );

            var projection = Builders<User>.Projection.Expression(u => u.ClassIds);

            List<string> classes = userCollection
                .Find(filter)
                .Project(projection)
                .FirstOrDefault();

            return classes;
        }
    }
}
