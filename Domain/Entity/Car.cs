using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dini_m3ak.Domain.Entity
{
    public class Car
    {
        [Key]
        public Guid Id { get; set; }
        public string CarName { get; set; } = null!;
        public int Seats { get; set; }
        public string UserId { get; set; } = null!;
        [NotMapped]
        public ApplicationUser User { get; set; } = null!;

        public DateTime CreatedOn { get; set; }
    }
}