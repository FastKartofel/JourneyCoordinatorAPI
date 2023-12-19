using JourneyCoordinatorAPI.Models;
using JourneyCoordinatorAPI.Repository.Interfaces;
using JourneyCoordinatorAPI.Services.Implementation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<JuorneyCoordinatorApiContext>(opt => {

    opt.UseSqlServer("Data Source=localhost\\SQLEXPRESS01;Initial Catalog=JuorneyCoordinatorAPI;Integrated Security=True; TrustServerCertificate=True");
    opt.LogTo(Console.WriteLine);
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<ITripService, TripService>();

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
