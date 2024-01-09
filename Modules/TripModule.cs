using dini_m3ak.Domain.Dtos.Trip;
using dini_m3ak.Repository;
using Microsoft.AspNetCore.Mvc;

namespace dini_m3ak.Modules
{
    public static class TripModule
    {
        public static IEndpointRouteBuilder AddTripModule(this IEndpointRouteBuilder routeBuilder)
        {

            routeBuilder.MapPost("/api/trip", (HttpContext httpContext, TripRepository tripRepository, [FromBody] CreateTripDto tripDto) =>
            {
                return Results.Ok(tripRepository.CreateTrip(tripDto, httpContext));
            }).RequireAuthorization();


            routeBuilder.MapGet("/api/trip", (TripRepository tripRepository) =>
            {
                return Results.Ok(tripRepository.GetAll());
            }).RequireAuthorization();


            routeBuilder.MapGet("/api/trip/query", ([FromQuery] Guid from, [FromQuery] Guid to, TripRepository tripRepository) =>
            {
                return Results.Ok(tripRepository.GetTripByCities(from, to));
            }).RequireAuthorization();


            routeBuilder.MapGet("/api/trip/search", ([FromQuery] Guid destinationCity, TripRepository tripRepository) =>
            {
                return Results.Ok(tripRepository.GetTripByDestination(destinationCity));
            }).RequireAuthorization();


            routeBuilder.MapPut("/api/trip/join/{tripId}", (Guid tripId, HttpContext httpContext, TripRepository tripRepository) =>
            {
                return Results.Ok(tripRepository.JoinTrip(tripId, httpContext));
            }).RequireAuthorization();

            return routeBuilder;
        }
    }
}