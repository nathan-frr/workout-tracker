namespace WorkoutTracker.Api.Models.Auth;

public record RegisterRequest(
    string Email,
    string Password,
    string? FirstName,
    string? LastName);

public record LoginRequest(
    string Email,
    string Password,
    bool RememberMe);

public record AuthResponse(
    Guid Id,
    string Email,
    string? FirstName,
    string? LastName);