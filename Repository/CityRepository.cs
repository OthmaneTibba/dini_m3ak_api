using dini_m3ak.Domain.Dtos.City;
using dini_m3ak.Domain.Entity;

namespace dini_m3ak.Repository
{
    public interface CityRepository
    {
        Task<City> createCity(CityDto cityDto);

        Task<List<City>> GetCities();
    }
}