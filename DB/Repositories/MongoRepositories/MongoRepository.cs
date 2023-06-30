using MongoDB.Driver;
using MyMicroservice.Controllers;

namespace ConsoleAppTest.Repositories.MongoRepositories
{
    public class MongoRepository : IMongoRepository
    {

        private readonly IMongoCollection<Entity> _weathercollection;

        public MongoRepository(IMongoClient client)
        {
            var database = client.GetDatabase("Mongo");
            var collection = database.GetCollection<Entity>(nameof(WeatherEntity));
            _weathercollection = collection;
        }

        public async Task<string> Create(Entity car)
        {
            await _weathercollection.InsertOneAsync(car);
            return car.Id;
        }

        public async Task<bool> Delete(Entity entity)
        {
            var filter = Builders<Entity>.Filter.Eq(c => c.Id, entity.Id);
            var result = await _weathercollection.DeleteOneAsync(filter);
            return result.DeletedCount == 1;
        }

        public Task<Entity> Get(Entity entity)
        {
            var filter = Builders<Entity>.Filter.Eq(c => c.Id, entity.Id);
            var car = _weathercollection.Find(filter).FirstOrDefaultAsync();
            return car;
        }
/*
    public async Task<IEnumerable<Car>> Get()
    {
        var cars = await _cars.Find(_ => true).ToListAsync();

        return cars;
    }

    public async Task<IEnumerable<Car>> GetByMake(string make)
    {
        var filter = Builders<Car>.Filter.Eq(c => c.Make, make);
        var cars = await _cars.Find(filter).ToListAsync();

        return cars;
    }

    public async Task<bool> Update(ObjectId objectId, Car car)
    {
        var filter = Builders<Car>.Filter.Eq(c => c.Id, objectId);
        var update = Builders<Car>.Update
            .Set(c => c.Make, car.Make)
            .Set(c => c.Model, car.Model)
            .Set(c => c.TopSpeed, car.TopSpeed);
        var result = await _cars.UpdateOneAsync(filter, update);

        return result.ModifiedCount == 1;
    }
*/
    }
}