namespace MyMicroservice.Controllers;

public interface IEntity
{
    public  string getStorePlace(Func<string> f)
    {
       return f();
    }


}