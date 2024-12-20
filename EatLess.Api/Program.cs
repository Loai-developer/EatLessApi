using EatLess.Api.OptionsSetup;
using EatLess.Application.Mappers;
using EatLess.Domain.Entities;
using EatLess.Domain.Repositories;
using EatLess.Infrastructure;
using EatLess.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var PresentationAssembly = typeof(EatLess.Presentation.AssemblyReference).Assembly;
builder.Services.AddControllers().AddApplicationPart(PresentationAssembly);

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(EatLess.Application.AssemblyReference.Assembly));

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString).ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning)));

builder
    .Services.Scan(selector => selector.FromAssemblies(
                EatLess.Infrastructure.AssemblyReference.Assembly,
                EatLess.Presentation.AssemblyReference.Assembly)
            .AddClasses(false)
            //.UsingRegistrationStrategy(RegistrationStrategy.Skip)
            .AsImplementedInterfaces()
            .WithScopedLifetime());

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IMealRepository, MealRepository>();

builder.Services.AddAuthorization();

builder.Services.AddIdentityCore<AppUser>(options =>
{
    //options.Password.RequireDigit = true;
    //options.Password.RequiredLength = 8;
    //options.Password.RequireNonAlphanumeric = false;
    //options.Password.RequireUppercase = true;
})
.AddEntityFrameworkStores<ApplicationDbContext>().AddApiEndpoints();

builder.Services.AddAuthentication().AddJwtBearer(options =>
{
    options.TokenValidationParameters = new()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = "EatLess",
        ValidAudience = "EatLess",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("super-secret-key-value-which-has-to-be-so-long!"))
    };
});

builder.Services.ConfigureOptions<JwtOptionsSetup>();
builder.Services.ConfigureOptions<JwtBearerOptionsSetup>();

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
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
