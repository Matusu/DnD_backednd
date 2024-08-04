using Microsoft.AspNetCore.Identity;

namespace webapi.Models;

public class appUser : IdentityUser
{
    public List<Campain>? Campains { get; set; }
    public List<Character>? Characters { get; set; }
}