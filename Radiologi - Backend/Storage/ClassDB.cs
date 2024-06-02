using MongoDB.Driver;
using MongoDB.Bson;
using Radiologi___Backend.Models;

namespace Radiologi___Backend.Storage
{
    public class ClassDB : IClassDB
    {
        const string connectionUri = "mongodb+srv://jmuncknielsen:KhLaePLs90UMJKDR@radiolgi.ffbz3p4.mongodb.net/?retryWrites=true&w=majority&appName=Radiolgi";
        MongoClient client;
        IMongoCollection<Class> classCollection;
        public ClassDB()
        {
            var settings = MongoClientSettings.FromConnectionString(connectionUri);
            // Set the ServerApi field of the settings object to set the version of the Stable API on the client
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            // Create a new client and connect to the server
            client = new MongoClient(settings);

            classCollection = client.GetDatabase("Radiologi").GetCollection<Class>("Classes");
        }

        public void CreateClass(Class newClass)
        {
            classCollection.InsertOne(newClass);
        }

        public Class GetClassById(string classId)
        {
            var filter = Builders<Class>.Filter.And(
                    Builders<Class>.Filter.Eq(u => u.Id, classId)
                    );

            Class foundClass = classCollection
                .Find(filter)
                .FirstOrDefault();

            return foundClass;
        }
    }
}
