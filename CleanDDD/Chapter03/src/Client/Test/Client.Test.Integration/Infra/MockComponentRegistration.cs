using Client.Presentation.Abstractions.Contracts;
using Client.Presentation.Abstractions.Dialogs;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;

namespace Client.Test.Integration.Infra;


public static class MockComponentRegistration
{
    public static IServiceCollection RegisterMockComponent(this IServiceCollection services)
        => services.AddTransient(s => MockDialogService());


    private static IDialogService MockDialogService()
    {
        var dialogService = Substitute.For<IDialogService>();
        dialogService
            .ShowDialogAsync(Arg.Any<object>(), Arg.Any<MessageButton>(), Arg.Any<Type>(), Arg.Any<string>())
            .Returns(Task.FromResult(MessageResult.OK));

        return dialogService;
    }
}
