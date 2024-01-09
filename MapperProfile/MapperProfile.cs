using AutoMapper;
using dini_m3ak.Domain.Dtos.Car;
using dini_m3ak.Domain.Dtos.City;
using dini_m3ak.Domain.Entity;

namespace dini_m3ak.MapperProfile
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Car, CarResponseDto>();
            CreateMap<CityDto, City>();
        }
    }
}