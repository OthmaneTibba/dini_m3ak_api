using dini_m3ak.Data;
using dini_m3ak.Domain.Dtos.Trip;
using dini_m3ak.Domain.Entity;
using dini_m3ak.Utils;
using Microsoft.EntityFrameworkCore;

namespace dini_m3ak.Repository.Impl
{
    public class TripRepositoryImpl : TripRepository
    {

        private readonly ApplicationDbContext _context;
        private readonly AuthUtils _authUtils;

        public TripRepositoryImpl(ApplicationDbContext context, AuthUtils authUtils)
        {
            _context = context;
            _authUtils = authUtils;
        }
        public async Task<Trip> CreateTrip(CreateTripDto tripDto, HttpContext httpContext)
        {

            ApplicationUser? user = await _authUtils.GetLoggedInUser(httpContext);

            if (user is null)
                throw new NullReferenceException();

            City? fromCity = await _context.Cities.Where(city => city.Id == tripDto.SourceCityId)
            .FirstOrDefaultAsync();

            if (fromCity is null)
                throw new NullReferenceException();

            City? destinationCity = await _context.Cities.Where(city => city.Id == tripDto.DestinationCityId)
            .FirstOrDefaultAsync();

            if (destinationCity is null)
                throw new NullReferenceException();

            Trip trip = new()
            {
                SourceCityId = fromCity.Id,
                Source = fromCity,
                Destination = destinationCity,
                DestinationCityId = destinationCity.Id,
                TripDate = tripDto.TripDate,
                User = user,
                UserId = user.Id,
                Seats = tripDto.Seats,
                RemainigSeats = tripDto.Seats
            };


            await _context.Trips.AddAsync(trip);
            await _context.SaveChangesAsync();
            return trip;
        }

        public async Task<IEnumerable<Trip>> GetAll()
        {
            return await _context.Trips.ToListAsync();
        }

        public async Task<IEnumerable<Trip>> GetTripByCities(Guid from, Guid to)
        {
            return await _context.Trips
            .Where(trip => trip.SourceCityId == from && trip.DestinationCityId == to)
            .ToListAsync();


        }

        public async Task<IEnumerable<Trip>> GetTripByDestination(Guid destinationCityId)
        {
            return await _context.Trips
            .Where(trip => trip.DestinationCityId == destinationCityId)
            .ToListAsync();
        }

        public async Task<Trip> JoinTrip(Guid tripId, HttpContext httpContext)
        {
            Trip? trip = await _context.Trips.Where(t => t.Id == tripId)

            .FirstOrDefaultAsync();

            if (trip is null)
                throw new NullReferenceException();


            if (trip.RemainigSeats < trip.Seats)
            {
                ApplicationUser? user = await _authUtils.GetLoggedInUser(httpContext);

                if (user is null)
                    throw new NullReferenceException();

                trip.Passangers.Add(user);
                await _context.SaveChangesAsync();
            }


            return trip;
        }
    }
}