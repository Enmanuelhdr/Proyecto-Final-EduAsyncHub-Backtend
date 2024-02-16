using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProyectoFinal.Configuration;
using ProyectoFinal.Context;

var builder = WebApplication.CreateBuilder(args);

string connectionString = builder.Configuration.GetConnectionString("Conex");
builder.Services.AddDbContext<EduAsyncHubContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddControllers();
builder.Services.GetDependencyInjections();


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
