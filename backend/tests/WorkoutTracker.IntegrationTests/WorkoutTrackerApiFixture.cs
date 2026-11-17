using System.Net.Http.Json;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Npgsql;

using WorkoutTracker.Infrastructure.Data;

namespace WorkoutTracker.IntegrationTests;

public sealed class WorkoutTrackerApiFixture : IAsyncLifetime
{
    public WorkoutTrackerApiFixture()
    {
        var configuration = new ConfigurationBuilder()
            .AddUserSecrets<WorkoutTrackerApiFixture>(optional: true)
            .AddEnvironmentVariables()
            .Build();
        var connectionString =
            configuration.GetConnectionString("WorkoutTrackerTest")
            ?? throw new InvalidOperationException(
                "Set ConnectionStrings:WorkoutTrackerTest with User Secrets or an environment variable before running integration tests.");

        var connectionStringBuilder = new NpgsqlConnectionStringBuilder(connectionString);
        if (connectionStringBuilder.Database != "workout_tracker_test")
        {
            throw new InvalidOperationException(
                "Integration tests can only run against the dedicated 'workout_tracker_test' database.");
        }

        ConnectionString = connectionString;
        Factory = new WorkoutTrackerApiFactory(connectionString);
        Client = Factory.CreateClient(new WebApplicationFactoryClientOptions
        {
            HandleCookies = true,
            BaseAddress = new Uri("https://localhost")
        });
    }

    public string ConnectionString { get; }

    public WorkoutTrackerApiFactory Factory { get; }

    public HttpClient Client { get; }

    public async Task InitializeAsync()
    {
        await using var scope = Factory.Services.CreateAsyncScope();
        var context = scope.ServiceProvider.GetRequiredService<WorkoutTrackerDbContext>();
        await context.Database.MigrateAsync();

        using var response = await Client.PostAsJsonAsync(
            "/api/auth/register",
            new
            {
                Email = $"integration-{Guid.NewGuid():N}@example.test",
                Password = "TestPassword1",
                FirstName = "Integration",
                LastName = "Test"
            });
        response.EnsureSuccessStatusCode();
    }

    public async Task DisposeAsync()
    {
        Client.Dispose();
        await Factory.DisposeAsync();
    }

    public sealed class WorkoutTrackerApiFactory(string connectionString) : WebApplicationFactory<Program>
    {
        protected override IHost CreateHost(IHostBuilder builder)
        {
            builder.ConfigureHostConfiguration(configuration =>
                configuration.AddInMemoryCollection(
                    new Dictionary<string, string?>
                    {
                        ["ConnectionStrings:WorkoutTracker"] = connectionString
                    }));

            return base.CreateHost(builder);
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseEnvironment("Testing");
        }
    }
}