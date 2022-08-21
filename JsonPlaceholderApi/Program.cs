using System.Reflection;
using Microsoft.OpenApi.Models;
using JsonPlaceholderApi.DataAccess.Api;
using JsonPlaceholderApi.Services.UserService;
using JsonPlaceHolderApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<IApiClient, ApiClient>();
builder.Services.AddSingleton<IUserService, UserService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "{JSON} Placeholder API",
        Description = "A minimal, C# API using [JSONPlaceholder](https://jsonplaceholder.typicode.com/) fake data.",
    });
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

IUserService userService = app.Services.GetRequiredService<IUserService>();
app.MapRoutes(userService);

app.Run();
