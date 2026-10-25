using WorkoutTracker.Infrastructure;
using WorkoutTracker.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    await using var scope = app.Services.CreateAsyncScope();

    var initializer = scope.ServiceProvider
        .GetRequiredService<WorkoutTrackerDbContextInitializer>();

    await initializer.InitializeAsync();
    await initializer.SeedAsync();

    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.Run();
