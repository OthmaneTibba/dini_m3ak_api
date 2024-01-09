using dini_m3ak.Data;
using dini_m3ak.Domain.Entity;
using dini_m3ak.Modules;
using dini_m3ak.Repository;
using dini_m3ak.Repository.Impl;
using dini_m3ak.Utils;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication()
.AddBearerToken(IdentityConstants.BearerScheme);
builder.Services.AddAuthorizationBuilder();



builder.Services.AddDbContext<ApplicationDbContext>(o =>
{
    o.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddIdentityCore<ApplicationUser>()
.AddEntityFrameworkStores<ApplicationDbContext>()
.AddApiEndpoints();

builder.Services.AddScoped<AuthUtils>();
builder.Services.AddScoped<CarRepository, CarRepositoryImpl>();
builder.Services.AddScoped<CityRepository, CityRepositoryImpl>();
builder.Services.AddScoped<TripRepository, TripRepositoryImpl>();


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapIdentityApi<ApplicationUser>();

app.AddCarModule();
app.AddCityModule();
app.AddTripModule();

app.Run();

