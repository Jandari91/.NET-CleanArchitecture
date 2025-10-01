using Grpc.Net.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Globalization;

namespace Client.Infrastructure.Abstractions.Registrations;

public static class GrpcRegistration
{
    public static IServiceCollection RegisterGrpc(this IServiceCollection services, IConfiguration configuration)
    {
        // 1) 옵션 바인딩
        var settings = new GrpcSettings();
        configuration.GetSection("Grpc").Bind(settings);

        // http(암호화X)로 gRPC를 쓰면 이 스위치가 필요할 수 있음
        // (HTTPS면 불필요)
        if (Uri.TryCreate(settings.Url, UriKind.Absolute, out var uri) &&
            uri.Scheme == Uri.UriSchemeHttp)
        {
            AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
        }

        // 2) LoggerFactory (LogLevel을 설정에서 읽음)
        var minLevel = ParseLogLevel(settings.LogLevel);

        var loggerFactory = LoggerFactory.Create(b =>
        {
            b.SetMinimumLevel(minLevel);
            // 필요하면 b.AddConsole(); 등 추가
        });

        // 3) 사이즈 파싱 (콤마/공백 제거 후 int로)
        int? recv = ParseSize(settings.Message?.MaxReceiveMessageSize);
        int? send = ParseSize(settings.Message?.MaxSendMessageSize);

        // 4) 채널 싱글턴 등록
        services.AddSingleton(sp =>
        {
            var options = new GrpcChannelOptions
            {
                LoggerFactory = loggerFactory,
                MaxReceiveMessageSize = recv,
                MaxSendMessageSize = send,
            };
            return GrpcChannel.ForAddress(settings.Url, options);
        });

        services.AddSingleton(sp =>
           new CleanDDD.Contracts.Employees.v1.EmployeeService.EmployeeServiceClient(
               sp.GetRequiredService<GrpcChannel>()));

        return services;
    }

    private static LogLevel ParseLogLevel(string? value) =>
        Enum.TryParse<LogLevel>(value, true, out var level) ? level : LogLevel.Information;

    private static int? ParseSize(string? value)
    {
        if (string.IsNullOrWhiteSpace(value)) return null;

        // 숫자만 남김(천단위 콤마/공백 제거)
        var digits = new string(value.Where(char.IsDigit).ToArray());

        return int.TryParse(digits, NumberStyles.Integer, CultureInfo.InvariantCulture, out var bytes)
            ? bytes
            : null;
    }

    public sealed class GrpcSettings
    {
        public string Url { get; set; } = "";
        public string LogLevel { get; set; } = "Information";
        public GrpcMessageSettings Message { get; set; } = new();
    }

    public sealed class GrpcMessageSettings
    {
        public string? MaxReceiveMessageSize { get; set; }
        public string? MaxSendMessageSize { get; set; }
    }
}
