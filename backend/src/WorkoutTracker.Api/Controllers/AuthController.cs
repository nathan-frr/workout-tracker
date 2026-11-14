
using System.ComponentModel.DataAnnotations;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using WorkoutTracker.Api.Models.Auth;
using WorkoutTracker.Infrastructure.Identity;

namespace WorkoutTracker.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(
    UserManager<ApplicationUser> userManager,
    SignInManager<ApplicationUser> signInManager) : ControllerBase
{
    private readonly UserManager<ApplicationUser> _userManager = userManager;
    private readonly SignInManager<ApplicationUser> _signInManager = signInManager;

    [HttpPost("register")]
    [AllowAnonymous]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        try
        {
            ValidateRegisterRequest(request);
        }
        catch (ArgumentException exception)
        {
            return ValidationProblem(detail: exception.Message);
        }

        var user = new ApplicationUser
        {
            UserName = request.Email,
            Email = request.Email,
            FirstName = request.FirstName,
            LastName = request.LastName
        };

        var result = await _userManager.CreateAsync(user, request.Password);

        if (!result.Succeeded)
        {
            foreach (var error in result.Errors)
            {
                var key = string.Empty;

                if (error.Code == "DuplicateEmail" || error.Code == "InvalidEmail" || error.Code == "DuplicateUserName")
                {
                    key = "Email";
                }
                else if (error.Code.StartsWith("Password", StringComparison.Ordinal))
                {
                    key = "Password";
                }

                ModelState.AddModelError(key, error.Description);
            }

            return ValidationProblem(ModelState);
        }

        // Automatically sign in the user after registration.
        await _signInManager.SignInAsync(user, isPersistent: false);

        return Ok(new AuthResponse(
            user.Id,
            user.Email!,
            user.FirstName,
            user.LastName));
    }

    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        try
        {
            ValidateLoginRequest(request);
        }
        catch (ArgumentException exception)
        {
            return ValidationProblem(detail: exception.Message);
        }

        var result = await _signInManager.PasswordSignInAsync(
            request.Email,
            request.Password,
            request.RememberMe,
            lockoutOnFailure: true);

        if (!result.Succeeded)
        {
            return Unauthorized("Invalid email or password.");
        }

        var user = await _userManager.FindByEmailAsync(request.Email);

        return user is null
            ? Unauthorized()
            : Ok(new AuthResponse(
                user.Id,
                user.Email!,
                user.FirstName,
                user.LastName));
    }

    [HttpPost("logout")]
    [Authorize]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();

        return NoContent();
    }

    [HttpGet("me")]
    [Authorize]
    public async Task<IActionResult> Me()
    {
        var user = await _userManager.GetUserAsync(User);

        return user is null
            ? Unauthorized()
            : Ok(new AuthResponse(
                user.Id,
                user.Email!,
                user.FirstName,
                user.LastName));
    }

    private static void ValidateRegisterRequest(RegisterRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Email))
        {
            throw new ArgumentException("Email is required.");
        }

        if (!new EmailAddressAttribute().IsValid(request.Email))
        {
            throw new ArgumentException("Email address is invalid.");
        }

        if (request.Email.Length > 256)
        {
            throw new ArgumentException("Email cannot exceed 256 characters.");
        }

        if (string.IsNullOrWhiteSpace(request.Password))
        {
            throw new ArgumentException("Password is required.");
        }

        if (request.FirstName?.Length > 100)
        {
            throw new ArgumentException("First name cannot exceed 100 characters.");
        }

        if (request.LastName?.Length > 100)
        {
            throw new ArgumentException("Last name cannot exceed 100 characters.");
        }
    }

    private static void ValidateLoginRequest(LoginRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Email))
        {
            throw new ArgumentException("Email is required.");
        }

        if (!new EmailAddressAttribute().IsValid(request.Email))
        {
            throw new ArgumentException("Email address is invalid.");
        }

        if (request.Email.Length > 256)
        {
            throw new ArgumentException("Email cannot exceed 256 characters.");
        }

        if (string.IsNullOrWhiteSpace(request.Password))
        {
            throw new ArgumentException("Password is required.");
        }
    }
}
