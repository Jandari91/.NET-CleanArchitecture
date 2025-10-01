extern alias Client;

using Api.Test.Integration.Infra;
using Grpc.Net.Client;

using ClientContracts = Client::CleanDDD.Contracts.Employees.v1;

namespace Api.Test.Integration.Controller;

public class EmployeeControllerTests : IClassFixture<TestWebFactory>
{
    private readonly TestWebFactory _factory;

    public EmployeeControllerTests(TestWebFactory factory) => _factory = factory;

    [Fact]
    public async Task GetEmployees_returns_items_from_server()
    {
        // Arrange
        using var httpClient = _factory.CreateDefaultClient();

        using var channel = GrpcChannel.ForAddress("http://localhost",
            new GrpcChannelOptions { HttpClient = httpClient });

        var client = new ClientContracts.EmployeeService.EmployeeServiceClient(channel);

        // Act
        var res = await client.GetEmployeesAsync(new ClientContracts.GetEmployeesRequest { });

        // Assert
        Assert.NotNull(res);
        Assert.Equal(4, res.Items.Count);
    }
}
