namespace MyMicroservice.Controllers;

public interface IRepositoryChooser
{
    public IRepository<Entity> choose(Entity entity);
}