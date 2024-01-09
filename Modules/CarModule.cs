using dini_m3ak.Domain.Dtos.Car;
using dini_m3ak.Domain.Entity;
using dini_m3ak.Repository;
using dini_m3ak.Utils;
using Microsoft.AspNetCore.Mvc;

namespace dini_m3ak.Modules
{
    public static class CarModule
    {
        public static IEndpointRouteBuilder AddCarModule(this IEndpointRouteBuilder routeBuilder)
        {

            routeBuilder.MapPost("/api/car", (CarRepository carRepository, [FromBody] CreateCarDto carDto, HttpContext httpContext) =>
            {
                return Results.Ok(carRepository.CreateCar(carDto, httpContext));
            }).RequireAuthorization();

            routeBuilder.MapGet("/api/car", async (CarRepository carRepository, HttpContext httpContext, AuthUtils authUtils) =>
            {
                ApplicationUser? user = await authUtils.GetLoggedInUser(httpContext);

                if (user is null)
                    return Results.Unauthorized();

                return Results.Ok(carRepository.GetCarsByUserId(user.Id));
            }).RequireAuthorization();

            return routeBuilder;
        }
    }
}