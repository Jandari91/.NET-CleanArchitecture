using Client.Presentation.Abstractions.Dialogs;
using Client.UI.Components.Molecules;
using System.Text.RegularExpressions;
using System.Windows;

namespace Client.UI.Abstractions.Dialogs;

internal class WindowService : IWindowService
{
    public async Task ShowWindowAsync<TViewModel>(TViewModel viewModel, Type? viewType = default, string title = "Windows") where TViewModel : class
    {
        var resolvedView = ResolveView(viewModel, viewType);
        var dialog = CreateWindow(title, resolvedView);

        var result = await System.Windows.Application.Current.Dispatcher.InvokeAsync(() => dialog.ShowDialog() ?? false);
    }

    // 1. View 이름 추정 + View 타입 탐색 + View 인스턴스 생성
    private FrameworkElement ResolveView<TViewModel>(TViewModel viewModel, Type? overrideType = default)
        where TViewModel : class
    {
        string viewName = ConvertToViewName(overrideType?.Name ?? viewModel.GetType().Name);

        var viewType = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(a => a.GetTypes())
            .FirstOrDefault(t => t.Name == viewName && typeof(FrameworkElement).IsAssignableFrom(t));

        if (viewType == null)
            throw new NullReferenceException($"View '{viewName}' not found for ViewModel '{viewModel.GetType().Name}'.");

        var view = Activator.CreateInstance(viewType) as FrameworkElement;

        if (view == null)
            throw new InvalidOperationException($"'{viewName}' is not a FrameworkElement.");

        view.DataContext = viewModel;
        return view;
    }

    // 2. DialogWindow 생성 및 View 크기 반영
    private ContentWindow CreateWindow(string title, FrameworkElement view)
    {
        var window = new ContentWindow(title)
        {
            ContentPanel = { Content = view },
            Owner = System.Windows.Application.Current.MainWindow,
            WindowStartupLocation = WindowStartupLocation.CenterOwner
        };

        double width = GetPreferredWidth(view);
        double height = GetPreferredHeight(view);

        if (width > 0)
        {
            window.Width = width + 20;
            window.MinWidth = width + 20;
        }


        if (height > 0)
        {
            window.Height = height + 85;
            window.MinHeight = height + 85;
        }


        return window;
    }

    // 3. ViewModel → View 이름 변환 규칙
    private static string ConvertToViewName(string viewModelName)
        => Regex.Replace(viewModelName, "ViewModel.*$", "View");


    private double GetPreferredWidth(FrameworkElement view)
    {
        if (!double.IsNaN(view.MinWidth) && view.MinWidth > 0)
            return view.MinWidth;

        if (!double.IsNaN(view.Width) && view.Width > 0)
            return view.Width;

        return 0;
    }

    private double GetPreferredHeight(FrameworkElement view)
    {
        if (!double.IsNaN(view.MinHeight) && view.MinHeight > 0)
            return view.MinHeight;

        if (!double.IsNaN(view.Height) && view.Height > 0)
            return view.Height;

        return 0;
    }
}
