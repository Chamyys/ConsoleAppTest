using ConsoleAppTest.Repositories.MongoRepositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Bson;

namespace MyMicroservice.Controllers;
[Route("[controller]")]
public class JsonController : Controller
{
    //private readonly IRepository<WeatherEntity>   _jsonRepository;
    //private readonly IRepository<WeatherEntity> _mongoRepository;
    private readonly IStorageManager _storageManager;
    public JsonController(IStorageManager storageManager)//
    {
        _storageManager = storageManager;
    }
    [HttpGet(Name = "Json")]
    public async Task<IActionResult> Temp() 
    { 
        Random rnd = new Random();
        WeatherEntity temp = new WeatherEntity
        {
            Id = ObjectId.GenerateNewId().ToString(), //generate? как работает парсер 
            location = "SPb",
            isRainyToday = true,
            name = "New NAme",
            temperature = rnd.Next(1,50)
        };
        //_jsonRepository.setPath(_path);
       
            await _storageManager.Create(temp);
       //     await _manager.Delete(temp);
         //  return Content("Hello00");
            return Content(_storageManager.Get(temp).Result.ToJson());
        
      
        
       // return Content(_jsonService.GetStudentByID("9999").ToJson());
       //return Content(_mongoRep.Get(temp).Result.ToJson());
       return Content(temp.temperature.ToJson());
    }
   
}