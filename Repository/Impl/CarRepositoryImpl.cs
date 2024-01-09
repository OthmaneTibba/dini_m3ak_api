using AutoMapper;
using dini_m3ak.Data;
using dini_m3ak.Domain.Dtos.Car;
using dini_m3ak.Domain.Entity;
using dini_m3ak.Utils;
using Microsoft.EntityFrameworkCore;

namespace dini_m3ak.Repository.Impl
{
    public class CarRepositoryImpl : CarRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly AuthUtils _authUtils;

        public CarRepositoryImpl(ApplicationDbContext context, IMapper mapper, AuthUtils authUtils)
        {
            _context = context;
            _mapper = mapper;
            _authUtils = authUtils;
        }


        public async Task<Car> CreateCar(CreateCarDto carDto, HttpContext httpContext)
        {

            ApplicationUser? user = await _authUtils.GetLoggedInUser(httpContext);

            Car car = new()
            {
                User = user!,
                UserId = user!.Id,
                CarName = carDto.CarName,
                CreatedOn = DateTime.UtcNow,
                Seats = carDto.Seats,
            };
            await _context.Cars.AddAsync(car);
            await _context.SaveChangesAsync();
            return car;
        }

        public async Task<IEnumerable<CarResponseDto>> GetCarsByUserId(string userId)
        {
            return await _context.Cars
            .Where(c => c.UserId == userId)
            .Select(car => _mapper.Map<Car, CarResponseDto>(car))
            .ToListAsync();
        }
    }
}