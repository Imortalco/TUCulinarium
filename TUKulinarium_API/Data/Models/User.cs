using Microsoft.AspNetCore.Identity;

namespace TUKulinarium_API.Data.Models
{
    public class User : IdentityUser
    {
        public UserProfile UserProfile { get; set; }
    }

}