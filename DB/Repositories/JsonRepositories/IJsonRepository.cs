using MongoDB.Bson;

namespace MyMicroservice.Controllers;

public interface IJsonRepository  : IRepository<Entity>
{
    public void setPath(string path);
}