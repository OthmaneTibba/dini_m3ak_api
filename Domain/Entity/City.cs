using System.ComponentModel.DataAnnotations;

namespace dini_m3ak.Domain.Entity
{
    public class City
    {
        [Key]
        public Guid Id { get; set; }
        public string CityName { get; set; } = null!;
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}