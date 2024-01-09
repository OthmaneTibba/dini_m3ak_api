namespace dini_m3ak.Domain.Dtos.Car
{
    public class CreateCarDto
    {
        public string CarName { get; set; } = null!;
        public string CarModel { get; set; } = null!;
        public string CarImage { get; set; } = null!;
        public int Seats { get; set; }
        public Guid UserId { get; set; }
    }
}