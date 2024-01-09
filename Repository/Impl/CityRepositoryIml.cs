using AutoMapper;
using dini_m3ak.Data;
using dini_m3ak.Domain.Dtos.City;
using dini_m3ak.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace dini_m3ak.Repository.Impl
{
    public class CityRepositoryImpl : CityRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CityRepositoryImpl(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<City> createCity(CityDto cityDto)
        {
            City city = _mapper.Map<CityDto, City>(cityDto);
            await _context.Cities.AddAsync(city);
            await _context.SaveChangesAsync();
            return city;
        }

        public async Task<List<City>> GetCities()
        {
            return await _context.Cities
            .ToListAsync();

        }
    }
}