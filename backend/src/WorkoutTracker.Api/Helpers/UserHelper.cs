using System.Security.Claims;

namespace WorkoutTracker.Api.Helpers;

public static class UserHelper
{
    public static Guid GetUserId(ClaimsPrincipal user)
    {
        var userId = user.FindFirstValue(ClaimTypes.NameIdentifier);

        return !Guid.TryParse(userId, out var parsedUserId)
            ? throw new UnauthorizedAccessException("The authenticated user does not have a valid user ID.")
            : parsedUserId;
    }
}