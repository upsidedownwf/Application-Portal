using ApplicationPortal.API.Repositories;
using ApplicationPortal.API.Services;
using Microsoft.Azure.Cosmos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure Cosmos DB client
builder.Services.AddSingleton<IFormRepository>(options =>
{
    string url = builder.Configuration["CosmosDb:Account"];
    string key = builder.Configuration["CosmosDb:Key"];
    string databaseName = builder.Configuration["CosmosDb:DatabaseName"];
    string containerName = builder.Configuration["CosmosDb:ContainerName"];
    var client = new CosmosClient(url, key); 
    client.CreateDatabaseIfNotExistsAsync(databaseName).GetAwaiter().GetResult();
    var database = client.GetDatabase(databaseName);
    database.CreateContainerIfNotExistsAsync(containerName, "/id").GetAwaiter().GetResult();
    return new FormRepository(client, databaseName, containerName);
});

// Add repositories and services
//builder.Services.AddScoped<IFormRepository, FormRepository>();
builder.Services.AddScoped<IFormService, FormService>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
app.UseRouting();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("./swagger/v1/swagger.json", "Application Portal API");
    c.RoutePrefix = "";
});
app.UseAuthorization();

app.MapControllers();

app.Run();
