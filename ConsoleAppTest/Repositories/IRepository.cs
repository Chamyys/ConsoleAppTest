using System.Net;

namespace MyMicroservice.Controllers;

public interface IRepository<T>
{
    public  Task<string> Create(T entity);
    public  Task<bool> Delete(T entity);
    public Task<Entity> Get(T entity);
}
