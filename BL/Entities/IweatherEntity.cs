using MongoDB.Bson;

namespace ClassLibrary1.Entities;

public interface IweatherEntity
{
 
    public string getWeatherStorePlace()
    {
        if (ObjectId.GenerateNewId().ToString().Length > 2)
        {
            return "ConsoleAppTest.Repositories.MongoRepositories";

        }
        return "ConsoleAppTest.Repositories.JsonRepositories";
    }
    
}