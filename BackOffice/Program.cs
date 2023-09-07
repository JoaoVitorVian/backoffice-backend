using Application.Interfaces;
using Application.Services;
using Application.ViewModels;
using AutoMapper;
using BackOffice.ViewModels.User;
using Domain.Entity;
using Infra.Context;
using Infra.Interfaces;
using Infra.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpClient();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc(name: "v1", new OpenApiInfo
    {
        Title = "Nerd Store API",
        Contact = new OpenApiContact() { Name = "João Vitor", Email = "joaovitorvian@gmail.com" },
        License = new OpenApiLicense() { Name = "MIT", Url = new Uri(uriString: "https://opensource.org/license/MIT") }

    });
});

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IDepartamentoRepository, DepartamentoRepository>();


var autoMapperConfig = new MapperConfiguration(cfg => {
    cfg.CreateMap<User, UserViewModel>().ReverseMap();
    cfg.CreateMap<CreateUserViewModel, UserViewModel>().ReverseMap();
    cfg.CreateMap<User, UserUpdateViewModel>().ReverseMap();
    cfg.CreateMap<UpdateUserViewModel, UserUpdateViewModel>().ReverseMap();

    cfg.CreateMap<Departamento, DepartamentoViewModel>().ReverseMap();
    cfg.CreateMap<CreateDepartamentoViewModel, DepartamentoViewModel>().ReverseMap();
    cfg.CreateMap<UpdateDepartamentoViewModel, DepartamentoViewModel>().ReverseMap();
});

var mapper = autoMapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

var env = builder.Environment;
var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
    .AddEnvironmentVariables()
    .Build();

var connectionString = configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ManagerContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddCors(options =>
{
    options.AddPolicy("DevelopmentPolicy",
        builder =>
        {
            builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});

if (env.IsDevelopment())
{
    builder.Configuration.AddUserSecrets<Program>();
}

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("DevelopmentPolicy");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
