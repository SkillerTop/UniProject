using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder();

builder.Services.AddTransient<Book>();
builder.Services.AddTransient<User>();

builder.Configuration.AddJsonFile("Route/Books.json");

var app = builder.Build();

app.Map("/", () => "Index Page");

app.Map("/Library", async (context) =>
{
    await context.Response.WriteAsync("Welcome to my library");
});

app.Map("/Library/books", async (context) =>
{
    var booksList = app.Configuration.GetSection("Books").Get<List<Book>>();

    foreach (var book in booksList)
    {
        await context.Response.WriteAsync($"Book: {book.Title} by {book.Author}\n");
    }
});

app.Map("/Library/Profile/{id:int?}", (int? id) =>
{
    var configFileName = id.HasValue && id >= 0 && id <= 5
        ? $"reader{id}.json"
        : "reader0.json";

    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Route/Users", configFileName);

    if (File.Exists(filePath))
    {
        var userInfo = JsonConvert.DeserializeObject<User>(File.ReadAllText(filePath));
        return $"Name: {userInfo.Name}, Age: {userInfo.Age}";
    }
    else
    {
        return "File configuration of user is not found.";
    }
});

app.MapGet("/allmaps", (IEnumerable<EndpointDataSource> endpointSources) =>
    string.Join("\n", endpointSources.SelectMany(source => source.Endpoints)));

app.Run();
