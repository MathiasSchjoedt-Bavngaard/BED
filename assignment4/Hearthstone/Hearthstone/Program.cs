using System.Text.Json.Serialization;
using Hearthstone.Services;
using Microsoft.EntityFrameworkCore.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("ConnectionString");

var hearthstoneServiceSettings = new HearthstoneServiceSettings()
{
    ConnectionString = connectionString,
    DatabaseName = "HearthstoneDatabase",
};


builder.Services.AddSingleton<HearthstoneServiceSettings>(hearthstoneServiceSettings);


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
