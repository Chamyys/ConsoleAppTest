using MongoDB.Bson;
using MongoDB.Driver;

namespace MyMicroservice.Controllers;

public interface IMongoRepository : IRepository<Entity>
{
    
}