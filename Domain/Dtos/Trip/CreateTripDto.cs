namespace dini_m3ak.Domain.Dtos.Trip
{
    public class CreateTripDto
    {
        public Guid SourceCityId { get; set; }
        public Guid DestinationCityId { get; set; }
        public DateTime TripDate { get; set; }
        public int Seats { get; set; }
    }
}