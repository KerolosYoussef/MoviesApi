using Microsoft.AspNetCore.Identity;

namespace MovieRate.Core.Models;

public class User : IdentityUser
{
    [MaxLength(50)]
    public string FirstName { get; set; }
    [MaxLength(50)]
    public string LastName { get; set; }
}