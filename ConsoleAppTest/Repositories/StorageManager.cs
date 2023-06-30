
namespace MyMicroservice.Controllers;

public class StorageManager<T> : IStorageManager
{
 
  private IEnumerable<IRepository<Entity>> _repositories;
  private IRepository<Entity> _repository;
  public StorageManager(IEnumerable<IRepository<Entity>> repositories)
  {
    _repositories = repositories;
  }

  public Task<string> Create(Entity entity)
  {
    choose(entity);
    return _repository.Create(entity);
  }

  public Task<bool> Delete(Entity entity)
  {
    choose(entity);

    return _repository.Delete(entity);
  }

  public Task<Entity> Get(Entity entity)
  {
    choose(entity);
    return _repository.Get(entity);
  }

  private void choose(Entity entity)
  {
    if (((WeatherEntity)entity).temperature > 25)
    {
      _repository = _repositories.FirstOrDefault(h => h.GetType().Namespace == "ConsoleAppTest.Repositories.MongoRepositories");

    }
    else
    {
      _repository = _repositories.FirstOrDefault(h => h.GetType().Namespace == "ConsoleAppTest.Repositories.JsonRepositories");

    }
    
  }
  

  
}