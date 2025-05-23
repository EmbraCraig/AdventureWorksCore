namespace AdventureWorksCore.E2eTests.Shared.WebApplicationFactory;

public class CustomWebApplicationFixture
{
    public CustomWebApplicationFactory Factory = null!;

    public CustomWebApplicationFixture()
    {
        Factory = new CustomWebApplicationFactory();

        Factory.InitializeDatabaseAndCheckpointAsync().GetAwaiter().GetResult();
    }
}
