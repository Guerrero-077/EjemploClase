using AutoMapper;
using Business;
using Business.ServiceRepository;
using Data.RepositoryData;
using DataGeneric.RepositoryDataGeneric;
using Entity.context;
using Entity.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Agregar servicios al contenedor
builder.Services.AddControllers(); // Importante para que los controladores funcionen correctamente

// Configuración de Swagger (documentación de API)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuración de servicios personalizados
builder.Services.AddScoped<PersonService>();
builder.Services.AddScoped<CityService>();
builder.Services.AddScoped<DepartamentService>();

builder.Services.AddScoped(typeof(DataGeneric<>));

// Configuración de AutoMapper
builder.Services.AddAutoMapper(typeof(Business.Map.AutoMapper));


// Configuración de la base de datos
builder.Services.AddDbContext<AplicationDbContext>(options =>
{
    options.UseSqlServer("name=DefaultConnection");
});

var app = builder.Build();

// Configuración del middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization(); // Si usas autenticación/autorización en tu API

app.MapControllers(); // Importante para mapear los controladores correctamente

app.Run();
