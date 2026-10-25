using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using WorkoutTracker.Application.Interfaces;
using WorkoutTracker.Infrastructure.Data;

namespace WorkoutTracker.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("WorkoutTracker")
            ?? throw new InvalidOperationException(
                "Connection string 'WorkoutTracker' is not configured.");

        services.AddDbContext<WorkoutTrackerDbContext>(options =>
            options.UseNpgsql(connectionString));
        services.AddScoped<IApplicationDbContext>(serviceProvider =>
            serviceProvider.GetRequiredService<WorkoutTrackerDbContext>());
        services.AddScoped<WorkoutTrackerDbContextInitializer>();

        return services;
    }
}
