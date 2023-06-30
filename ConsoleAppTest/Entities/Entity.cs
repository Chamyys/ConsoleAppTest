using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MyMicroservice.Controllers;

public class Entity
{
    //[BsonId]
    public string Id { get; set; }
}