namespace MyMicroservice.Controllers;

public interface IStorageManager
{
    public Task<string> Create(Entity car);

    public Task<bool> Delete(Entity entity);
    public Task<Entity> Get(Entity entity);
}