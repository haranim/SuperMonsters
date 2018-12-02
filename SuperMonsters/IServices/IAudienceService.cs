using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using SuperMonsters.Models;

namespace SuperMonsters.IServices
{
    public interface IAudienceService
    {
        List<Audience> Get();
        Audience Get(string id);
        Audience Create(Audience audience);
        void Update(string id, Audience audienceIn);
        void Remove(ObjectId id);
    }
}
