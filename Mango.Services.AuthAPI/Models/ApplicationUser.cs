using Microsoft.AspNetCore.Identity;

namespace Mango.Services.AuthAPI.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
