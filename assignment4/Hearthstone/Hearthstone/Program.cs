using System.Text.Json.Serialization;
using Hearthstone.Services;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Hearthstone.Controllers;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = "mongodb://localhost:27017";
connectionString = builder.Configuration.GetConnectionString("default");

var hearthstoneServiceSettings = new HearthstoneServiceSettings()
{
    ConnectionString = connectionString,
    DatabaseName = "HearthstoneDB"
};


builder.Services.AddSingleton<HearthstoneServiceSettings>(hearthstoneServiceSettings);
Console.WriteLine(hearthstoneServiceSettings.ConnectionString);
builder.Services.AddSingleton<HearthstoneService>(new HearthstoneService(hearthstoneServiceSettings));

builder.Services.AddControllers(options =>
{
    options.SuppressAsyncSuffixInActionNames = false;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
