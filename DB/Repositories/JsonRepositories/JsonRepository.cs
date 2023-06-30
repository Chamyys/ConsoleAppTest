using FluentResults;
using Microsoft.Extensions.Options;
using MyMicroservice.Controllers;

namespace ConsoleAppTest.Repositories.JsonRepositories
{

    public class JsonRepository : IJsonRepository
    {
        private string path;
        
        public JsonRepository(IOptions<JSONPATH> _path)//
        {
            path = _path.Value.ConnectionString;
        }
       
        public async Task<Entity> Get(Entity weather)
        {
            var executionResult = false;
            try
            {
                JsonSerialisation.Read(weather.Id, path);
                executionResult = true;
                return await Task<Entity>.FromResult(weather);
            }
            catch (Exception e)
            {
                WeatherEntity notFound = new WeatherEntity();
                notFound.Id = "FILE NOT FOUND";
                return notFound;
            }
        }

        public async Task<string> Create(Entity weather)

        {
            bool executionResult = false;
            try
            {
                JsonSerialisation.Write(weather, path);
                executionResult = true;
                return await Task.FromResult(weather.Id);
            }
            catch (Exception e)
            {
                return await Task.FromResult("Exception");
            }
          
        }

        public void setPath(string path)
        {
            this.path = path;
        }
      

        public async Task<bool> Delete(Entity ent)
        {
            var path = this.path + ent.Id + ".json";
            var fileInf = new FileInfo(path);
            var executionResult = false;
            try
            {
                fileInf.Delete();
                executionResult = true;
                return await Task.FromResult(executionResult);
            }
            catch (Exception e)
            {
                return await Task.FromResult(executionResult);
            }
        }

    }
}