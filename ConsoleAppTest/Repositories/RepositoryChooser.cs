namespace MyMicroservice.Controllers;

public class RepositoryChooser<T> : IRepositoryChooser
{
    private IEnumerable<IRepository<Entity>> _repositories;
    public RepositoryChooser(IEnumerable<IRepository<Entity>> repositories)
    {
        _repositories = repositories;
    }
    
    public IRepository<Entity> choose(Entity entity)
    {
        if (((WeatherEntity)entity).temperature > 25)
        {
            return _repositories.FirstOrDefault(h => h.GetType().Namespace == "ConsoleAppTest.Repositories.MongoRepositories");

        }
        else
        {
            return _repositories.FirstOrDefault(h => h.GetType().Namespace == "ConsoleAppTest.Repositories.JsonRepositories");

        }
    
    }
}