using dini_m3ak.Domain.Dtos.Trip;
using dini_m3ak.Domain.Entity;

namespace dini_m3ak.Repository
{
    public interface TripRepository
    {
        Task<Trip> CreateTrip(CreateTripDto tripDto, HttpContext httpContext);

        Task<IEnumerable<Trip>> GetAll();

        Task<IEnumerable<Trip>> GetTripByCities(Guid from, Guid to);

        Task<IEnumerable<Trip>> GetTripByDestination(Guid destinationCityId);
        Task<Trip> JoinTrip(Guid tripId, HttpContext httpContext);
    }
}