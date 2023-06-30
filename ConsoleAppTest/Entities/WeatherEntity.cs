using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MyMicroservice.Controllers;

public class WeatherEntity : Entity
{
        
     
        public string name { get; set; } = null!;

        public int temperature { get; set; }

        public string location { get; set; } = null!;

        public bool isRainyToday { get; set; } = false;
    
}
