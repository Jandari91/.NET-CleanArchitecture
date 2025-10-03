using Client.Presentation.ViewModels.Employee;
using Client.Test.Integration.Infra;
using Grpc.Net.Client;
using Microsoft.Extensions.DependencyInjection;

namespace Client.Test.Integration.ViewModel;

public class EmployeeViewModelTest : IClassFixture<ApiServiceTestFactory>
{
    private readonly ApiServiceTestFactory _apiFactory;

    public EmployeeViewModelTest(ApiServiceTestFactory apiFactory)
    {
        _apiFactory = apiFactory;
    }

    [Fact]
    public async Task EmployeeViewModel_Should_Load_Employees_From_ApiService()
    {
        using var httpClient = _apiFactory.CreateDefaultClient();

        using var channel = GrpcChannel.ForAddress("http://localhost", new GrpcChannelOptions
        {
            HttpClient = httpClient
        });

        // xUnit이 lifecycle을 관리해줌
        var hostFactory = new TestHostFactory(channel);
        await hostFactory.InitializeAsync(); // <-- 직접 Start
        try
        {
            var vm = hostFactory.Services.GetRequiredService<EmployeeViewModel>();

            await vm.LoadEmployeesCommand.ExecuteAsync(null);

            Assert.NotNull(vm.Employees);
            Assert.NotEmpty(vm.Employees);
        }
        finally
        {
            await hostFactory.DisposeAsync();
        }
    }
}