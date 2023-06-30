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



var app = builder.Build();


app.Run();

    