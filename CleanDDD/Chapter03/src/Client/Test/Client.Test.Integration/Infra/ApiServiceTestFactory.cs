using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Client.Test.Integration.Infra;

public class ApiServiceTestFactory : WebApplicationFactory<Program>
{
    private readonly Action<IServiceCollection>? _configureTestServices;

    public ApiServiceTestFactory() : this(null) { }

    // 테스트마다 DI 커스터마이징할 때 쓰는 비공개 생성자
    private ApiServiceTestFactory(Action<IServiceCollection>? configure)
    {
        _configureTestServices = configure;
    }

    // 필요 시 커스텀 DI를 적용한 새 팩토리 반환 (테스트 내에서 사용)
    public ApiServiceTestFactory WithServices(Action<IServiceCollection> configure)
        => new ApiServiceTestFactory(configure);

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.UseEnvironment("Testing");

        //  테스트 종료 시 EventLogInternal dispose 예외 방지
        builder.ConfigureLogging(logging =>
        {
            logging.ClearProviders();
            logging.AddConsole();
            logging.AddDebug();
        });

        builder.ConfigureTestServices(services =>
        {
            _configureTestServices?.Invoke(services);
        });
    }
}