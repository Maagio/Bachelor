using System.Text.Json;
using MongoDB.Driver;
using MongoDB.Bson;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using MongoDB.Bson.Serialization;
using Radiologi___Backend.Models;

namespace Radiologi___Backend.Storage
{
    public class TestDB : ITestDB
    {
        const string connectionUri = "mongodb+srv://jmuncknielsen:KhLaePLs90UMJKDR@radiolgi.ffbz3p4.mongodb.net/?retryWrites=true&w=majority&appName=Radiolgi";
        MongoClient client;
        IMongoCollection<Questionare> testCollection;
        IMongoCollection<AnsweredTest> answeredTestCollection;
        public TestDB()
        {
            var settings = MongoClientSettings.FromConnectionString(connectionUri);
            // Set the ServerApi field of the settings object to set the version of the Stable API on the client
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            // Create a new client and connect to the server
            client = new MongoClient(settings);

            testCollection = client.GetDatabase("Radiologi").GetCollection<Questionare>("Tests");
            answeredTestCollection = client.GetDatabase("Radiologi").GetCollection<AnsweredTest>("FilledTests");
        }

        public void CreateTest(Questionare questionare)
        {
            testCollection.InsertOne(questionare);
        }

        public List<Questionare> GetTestsByClassId(string classId)
        {
            var filter = Builders<Questionare>.Filter.And(
                    Builders<Questionare>.Filter.Eq(u => u.ClassId, classId)
                    );

            List<Questionare> classes = testCollection
                .Find(filter)
                .ToList();

            return classes;
        }
        public Questionare GetTestByTestId(string id)
        {
            var filter = Builders<Questionare>.Filter.And(
                    Builders<Questionare>.Filter.Eq(u => u.Id, id)
                    );

            Questionare questionare = testCollection
                .Find(filter)
                .FirstOrDefault();

            return questionare;
        }
        public void SaveAnswers(AnsweredTest answeredTest)
        {
            answeredTestCollection.InsertOne(answeredTest);
        }
    }
}
