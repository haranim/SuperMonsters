using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SuperMonsters.Models
{
    public class Audience
    {
        public ObjectId Id { get; set; }

        [BsonElement("FirstName")]
        public string FirstName { get; set; }

        [BsonElement("LastName")]
        public string LastName { get; set; }

        [BsonElement("Gender")]
        public string Gender { get; set; }

        [BsonElement("Telephone")]
        public string Telephone { get; set; }

        [BsonElement("Email")]
        public string Email { get; set; }

        [BsonElement("Character")]
        public string Character { get; set; }

        [BsonElement("Rating")]
        public int Rating { get; set; }
    }
}
