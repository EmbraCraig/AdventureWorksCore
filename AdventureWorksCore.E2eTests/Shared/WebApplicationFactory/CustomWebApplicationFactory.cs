using AdventureWorksCore.Application.Common.Interfaces;
using AdventureWorksCore.E2eTests.Shared.Extensions;
using AdventureWorksCore.Infrastructure.Persistence;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Respawn;
using Respawn.Graph;

namespace AdventureWorksCore.E2eTests.Shared.WebApplicationFactory;

public class CustomWebApplicationFactory : WebApplicationFactory<Program>
{
    private Checkpoint _checkpoint = null!;
    private readonly Mock<IDateTimeService> _dateTimeServiceMock;
    public DateTime? MockedCurrentDateTime { get; set; }

    public CustomWebApplicationFactory()
    {
        _dateTimeServiceMock = new Mock<IDateTimeService>();
        _dateTimeServiceMock.Setup(_ => _.Now)
            .Returns(() => MockedCurrentDateTime ?? DateTime.UtcNow);
    }

    public async Task ResetState()
    {
        var services = GetScopedServiceProvider();

        var configuration = services.GetRequiredService<IConfiguration>();

        var connectionString = configuration.GetConnectionString("SqlServer") ?? throw new Exception("No connection string defined.");
        await _checkpoint.Reset(connectionString);
    }

    public IServiceProvider GetScopedServiceProvider()
    {
        return Services.CreateScope().ServiceProvider;
    }

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.UseEnvironment("E2eTests");

        builder.ConfigureServices((context, services) =>
        {
            services.RemoveServiceOfType<IDateTimeService>();
            services.AddSingleton(_dateTimeServiceMock.Object);
        });

        base.ConfigureWebHost(builder);
    }

    public async Task InitializeDatabaseAndCheckpointAsync()
    {
        using var scope = Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        await dbContext.Database.EnsureDeletedAsync();
        await dbContext.Database.MigrateAsync();

        _checkpoint = new Checkpoint
        {
            TablesToIgnore = [new Table("__EFMigrationsHistory"),
            new Table("UnitMeasure")],
        };
    }
}
