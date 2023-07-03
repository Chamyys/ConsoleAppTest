

using ClassLibrary1.Entities;

namespace MyMicroservice.Controllers;

public class WeatherEntity : Entity, IWeatherGroupStoreLogic
{
    public string name { get; set; } = null!;

        public int temperature { get; set; }

        public string location { get; set; } = null!;

        public bool isRainyToday { get; set; } = false;
        
        public override string  getRealStorePlace()
        {
            return  IStoreSettingsManager.GetSettings(this.GetType(), this,"temperature");
        }
        
}
