using dini_m3ak.Domain.Dtos.City;
using dini_m3ak.Domain.Entity;
using dini_m3ak.Repository;
using Microsoft.AspNetCore.Mvc;

namespace dini_m3ak.Modules
{
    public static class CityModule
    {
        public static IEndpointRouteBuilder AddCityModule(this IEndpointRouteBuilder routeBuilder)
        {

            routeBuilder.MapPost("/api/city", (CityRepository cityRepository, [FromBody] CityDto cityDto) =>
            {
                return Results.Ok(cityRepository.createCity(cityDto));
            }).RequireAuthorization();


            routeBuilder.MapGet("/api/city", (CityRepository cityRepository) =>
            {
                return Results.Ok(cityRepository.GetCities());
            }).RequireAuthorization();

            return routeBuilder;
        }
    }
}