namespace Client.Presentation.Abstractions.Dialogs;

public interface IExceptionService
{
    Task ShowExceptionAsync(Exception e);
}
