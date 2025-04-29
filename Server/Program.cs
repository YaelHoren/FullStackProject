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

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddSingleton<DatabaseManager>();
builder.Services.AddSingleton<IBL, BLManager>();
builder.Services.AddControllers();



var app = builder.Build();
app.MapControllers();
app.Run();