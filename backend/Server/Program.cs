using BL;
using BL.API;
using Dal;

//var builder = WebApplication.CreateBuilder(args);
//var app = builder.Build();


//app.MapGet("/", () => "Hello World!");

//app.Run();
using Dal.API;
using Dal.models;
using Dal.Services;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddScoped<DatabaseManager>();
builder.Services.AddSingleton<IBL, BLManager>();
builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder => builder.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});

var app = builder.Build();
app.UseCors("AllowAllOrigins");





app.MapControllers();
app.Run();