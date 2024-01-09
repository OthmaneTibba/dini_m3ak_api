
using System.Security.Claims;
using dini_m3ak.Data;
using dini_m3ak.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace dini_m3ak.Utils
{
    public class AuthUtils
    {

        private readonly ApplicationDbContext _context;


        public AuthUtils(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ApplicationUser?> GetLoggedInUser(HttpContext httpContext)
        {

            string? userId = httpContext.User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier)
            .FirstOrDefault()?.Value;

            if (userId is null)
                return null;

            ApplicationUser? user = await _context.Users.Where(u => u.Id == userId).FirstOrDefaultAsync();

            if (user is null)
                return null;

            return user;


        }
    }
}