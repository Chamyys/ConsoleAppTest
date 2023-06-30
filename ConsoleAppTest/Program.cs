using ConsoleAppTest;
using ConsoleAppTest.Repositories.JsonRepositories;
using ConsoleAppTest.Repositories.MongoRepositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using MyMicroservice.Controllers;
using ThirdParty.Json.LitJson;



// Add services to the container.
var builder = WebApplication.CreateBuilder(args);



builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<IJsonRepository, JsonRepository>();
builder.Services.AddControllers();



builder.Services.AddMvc();
builder.Services.AddOptions();

//builder.Services.Configure<JSONPATH>(builder.Configuration.GetSection("JSONPATH"));
//builder.Configuration.GetSection("JSONPATH").Bind(new JSONPATH());


//builder.Configuration.AddJsonFile("/home/egor/RiderProjects/ConsoleAppTest/ConsoleAppTest/1.json");
//builder.Services.Configure<JSONPATH>(builder.Configuration);

builder.Configuration.AddJsonFile("/home/egor/RiderProjects/ConsoleAppTest/ConsoleAppTest/app-settings.json");
builder.Services.Configure<JSONPATH>(builder.Configuration.GetSection("JSONPATH"));

builder.Services.BuildServiceProvider();


builder.Services.AddTransient<IMongoRepository, MongoRepository>();
builder.Services.Configure<IMongoRepository>(builder.Configuration.GetSection("Mongo"));


builder.Services.AddSingleton<IMongoClient>(sp => new MongoClient(builder.Configuration.GetConnectionString("Mongo")));


builder.Services.AddTransient<IRepository<Entity>, JsonRepository>();
builder.Services.AddTransient<IRepository<Entity>, MongoRepository>();



builder.Services.AddTransient<IStorageManager, StorageManager>(); //что я хочу прокидывать в конструктор

//builder.Services.AddTransient<IStorageManager, StorageManager<IRepository<WeatherEntity>>>(); //что я хочу прокидывать в конструктор


builder.Services.AddTransient<IRepositoryChooser, RepositoryChooser<IRepository<WeatherEntity>>>(); //что я хочу прокидывать в конструктор



//builder.Services.AddTransient<IRepository<Entity>, MongoRepository>();




    
//builder.Services.AddTransient<IStoragePlaceChooserManager,StoragePlaceChooserManager>();
//builder.Services.AddTransient<IStoragePlaceChooserWeather,StoragePlaceChooserWeather>();


var app = builder.Build();



/*
JsonPath path = new JsonPath();
builder.Services.AddSingleton(path);

var app = builder.Build();
app.Map("/", (IOptions<JsonPath> options) =>
{
     path = options.Value;  //получаем переданные через Options объект Person
    return path.ToString();
});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
*/
app.UseAuthorization();
app.MapControllers();

/*
app.MapGet("/", async (MongoClient client) =>     // получаем MongoClient через DI
{
    var db = client.GetDatabase("test");    // обращаемся к базе данных
    var collection = db.GetCollection<BsonDocument>("users"); // получаем коллекцию users
    // для теста добавляем начальные данные, если коллекция пуста
    if (await collection.CountDocumentsAsync("{}") == 0)
    {
        await collection.InsertManyAsync(new List<BsonDocument>
        {
            new BsonDocument{ { "Name", "Tom" },{"Age", 22}},
            new BsonDocument{ { "Name", "Bob" },{"Age", 42}}
        });
    }
    var users =  await collection.Find("{}").ToListAsync();
    return users.ToJson();  // отправляем клиенту все документы из коллекции
});
*/
app.Run();

    