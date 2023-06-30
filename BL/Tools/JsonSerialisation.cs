
using Newtonsoft.Json;
using JsonConvert = Newtonsoft.Json.JsonConvert;

namespace MyMicroservice.Controllers;


public class JsonSerialisation
{
    
         public static  WeatherEntity Read(string id, string path)
         { 
             WeatherEntity a = JsonConvert.DeserializeObject<WeatherEntity>(File.ReadAllText(path + id + ".json"));
           
             return a;
         }
        public static void Write(Entity model, string path)
        {
             File.WriteAllText(path + model.Id + ".json", JsonConvert.SerializeObject(model));
        }
        
}