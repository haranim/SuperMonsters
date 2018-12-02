using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using SuperMonsters.Models;
using SuperMonsters.IServices;

namespace SuperMonsters.Services
{
    public class AudienceService: IAudienceService
    {
        private readonly IMongoCollection<Audience> _audience;

        public AudienceService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("MonstersDb"));
            var database = client.GetDatabase("MonstersDb");
            _audience = database.GetCollection<Audience>("Audience");
        }

        public List<Audience> Get()
        {
            return _audience.Find(audience => true).ToList();
        }

        public Audience Get(string id)
        {
            var docId = new ObjectId(id);

            return _audience.Find<Audience>(audience => audience.Id == docId).FirstOrDefault();
        }

        public Audience Create(Audience audience)
        {
            _audience.InsertOne(audience);
            return audience;
        }

        public void Update(string id, Audience audienceIn)
        {
            var docId = new ObjectId(id);

            _audience.ReplaceOne(audience => audience.Id == docId, audienceIn);
        }

        public void Remove(ObjectId id)
        {
            _audience.DeleteOne(audience => audience.Id == id);
        }
    }
}
