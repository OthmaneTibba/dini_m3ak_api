using dini_m3ak.Domain.Dtos.Car;
using dini_m3ak.Domain.Entity;

namespace dini_m3ak.Repository
{
    public interface CarRepository
    {
        Task<Car> CreateCar(CreateCarDto carDto, HttpContext httpContext);
        Task<IEnumerable<CarResponseDto>> GetCarsByUserId(string userId);
    }
}