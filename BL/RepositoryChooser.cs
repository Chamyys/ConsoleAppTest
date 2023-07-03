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
        return _repositories.FirstOrDefault(h => h.GetType().Namespace == entity.getStorePlace(entity.getRealStorePlace)); // можно прокидывать изначатльный тип объекта вторым параметром и приводить его тут 
    }
}