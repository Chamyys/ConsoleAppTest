

using ClassLibrary1.Entities;

namespace MyMicroservice.Controllers;

public class WeatherEntity : Entity, IweatherEntity
{
        
     
        public string name { get; set; } = null!;

        public int temperature { get; set; }

        public string location { get; set; } = null!;

        public bool isRainyToday { get; set; } = false;
    
}
