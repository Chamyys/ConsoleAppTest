using System.Reflection;
using System.Reflection.Emit;
using MyMicroservice.Controllers;

namespace ClassLibrary1.Entities;

public interface IStoreSettingsManager
{
    public static string GetSettings(Type type, Entity entity, string myField)
    {
        Type[] itf = type.GetInterfaces();
        foreach (Type i in itf)
        {
            if (!i.IsAssignableFrom(typeof(Entity)))
             {
                 string a =i.GetMethod("getSettings").Invoke(entity, new object[] {i.GetField(myField)}).ToString();
                 return a;
             };
        }

        return null;
    }
}