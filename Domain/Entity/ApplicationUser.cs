using Microsoft.AspNetCore.Identity;

namespace dini_m3ak.Domain.Entity
{
    public class ApplicationUser : IdentityUser
    {
        public List<Car> Cars { get; set; } = new();
    }
}