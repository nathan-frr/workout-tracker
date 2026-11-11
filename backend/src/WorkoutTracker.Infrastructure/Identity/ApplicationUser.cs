using Microsoft.AspNetCore.Identity;

namespace WorkoutTracker.Infrastructure.Identity;

public class ApplicationUser : IdentityUser<Guid>
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
}