using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ContactsApi.Models
{
    public class Contacts
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("username")]
        public string Username { get; set; }
        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("phone")]
        public string Phone { get; set; }
        [BsonElement("email")]
        public string Email { get; set; }
        [BsonElement("address")]
        public string Address { get; set; }
        [BsonElement("image")]
        public string Image { get; set; }
        [BsonElement("notes")]
        public string Notes { get; set; }
    }
}
