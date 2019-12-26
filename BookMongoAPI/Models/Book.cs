using BookMongoAPI.Models.Enums;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace BookMongoAPI.Models
{
    public class Book
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        
        [BsonElement("Name")]
        [JsonProperty("Name")]
        public string BookName { get; set; }

        public decimal Price { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public Category Category { get; set; }

        public string Author { get; set; }
    }
}
