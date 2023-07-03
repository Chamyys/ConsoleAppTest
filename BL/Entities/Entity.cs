

namespace MyMicroservice.Controllers;

public abstract class Entity : IEntity
{
    public string Id { get; set; }

    public string getStorePlace(Func<string> f)
    {
        return f();
    }

    public abstract string getRealStorePlace();
}