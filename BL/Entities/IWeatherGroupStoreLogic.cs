namespace ClassLibrary1.Entities;

public interface IWeatherGroupStoreLogic 
{
     public string getSettings (int temperature)
    {
        if (temperature > 25)
        {
            return "ConsoleAppTest.Repositories.MongoRepositories";
        }
        return "ConsoleAppTest.Repositories.JsonRepositories";
    }
    
}