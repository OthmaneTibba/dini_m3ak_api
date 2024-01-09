using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dini_m3ak.Domain.Entity
{
    public class Trip
    {
        [Key]
        public Guid Id { get; set; }
        public Guid SourceCityId { get; set; }
        [NotMapped]
        public City Source { get; set; } = null!;
        public Guid DestinationCityId { get; set; }
        [NotMapped]
        public City Destination { get; set; } = null!;
        public DateTime TripDate { get; set; }
        public string UserId { get; set; } = null!;
        public int Seats { get; set; }
        public int RemainigSeats { get; set; }
        [NotMapped]
        public ApplicationUser User { get; set; } = null!;
        public List<ApplicationUser> Passangers { get; set; } = new();
    }
}