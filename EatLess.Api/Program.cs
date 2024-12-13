using EatLess.Application.Mappers;
using EatLess.Domain.Repositories;
using EatLess.Infrastructure;
using EatLess.Infrastructure.Repositories;
using EatLess.Presentation;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var PresentationAssembly = typeof(AssemblyReference).Assembly;
builder.Services.AddControllers().AddApplicationPart(PresentationAssembly);

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(EatLess.Application.AssemblyReference.Assembly));

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IMealRepository, MealRepository>();

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
