using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ProyectoFinal.Configuration;
using ProyectoFinal.Context;
using ProyectoFinal.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

var misReglasCors = "ReglasCors";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: misReglasCors,
        builder =>
        {
            builder.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod()
                .WithOrigins("http://127.0.0.1:5500")
                .AllowCredentials();
        });
});

string connectionString = builder.Configuration.GetConnectionString("Conex");
builder.Services.AddDbContext<EduAsyncHubContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddControllers();
builder.Services.GetDependencyInjections();

// Añadir SignalR
builder.Services.AddSignalR();


// Configure JWT Authentication
builder.Services.AddAuthentication(config =>
{
    config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(config =>
{
    config.RequireHttpsMetadata = false;
    config.SaveToken = true;
    config.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["settings:Key"]))
    };
});

// Configure Swagger/OpenAPI
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Proyecto Final", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[]{}
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting(); // Agrega esta línea para configurar el middleware de enrutamiento de extremos

app.UseCors(misReglasCors);
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

// Mapeo del hub de SignalR
app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<ChatService>("/chatHub"); // Aquí mapeamos el Hub
    endpoints.MapControllers();
});

app.Run();
