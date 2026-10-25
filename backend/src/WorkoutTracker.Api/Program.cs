using WorkoutTracker.Infrastructure;
using WorkoutTracker.Infrastructure.Data;
using WorkoutTracker.Application.Services.Exercises;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddScoped<IExerciseService, ExercisesService>();

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

app.MapControllers();

app.Run();
