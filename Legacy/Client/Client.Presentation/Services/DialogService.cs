using Client.Business.Core.Application.Dialogs;
using Client.Business.Core.Application.Mvvm;
using Client.Presentation.Views.Windows;
using LanguageExt;
using System.Reflection;
using System.Windows.Controls;
using System.Windows.Data;

namespace Client.Presentation.Services;

public class DialogService : IDialogService
{
    public void Show<TViewModel>(IDialogBase viewModel, Action<Option<bool>> callback)
    {
        var view = typeof(TViewModel).Name.Replace("ViewModel", "View");

        Assembly assembly = Assembly.GetExecutingAssembly();
        Type type = assembly.GetTypes()
            .FirstOrDefault(type => type.Name == view) ?? throw new NullReferenceException();

        ShowDialogInternal(type, viewModel, callback);
    }

    private static void ShowDialogInternal(Type type, IDialogBase viewModel, Action<Option<bool>> callback)
    {
        var dialog = new DialogWindow();

        EventHandler? closeEventHandler = null;
        closeEventHandler = (s, e) =>
        {
            var result = (!dialog.DialogResult.HasValue || !dialog.DialogResult.Value) 
                            ? Option<bool>.None : Option<bool>.Some(dialog.DialogResult.Value);
            callback(result);
            dialog.Closed -= closeEventHandler;
        };
        dialog.Closed += closeEventHandler;

        var content = Activator.CreateInstance(type, viewModel);
        dialog.DataContext = content;

        Binding binding = new Binding(nameof(viewModel.IsValid));
        binding.Source = viewModel;
        BindingOperations.SetBinding(dialog.OkButton, Button.IsEnabledProperty, binding);

        dialog.ShowDialog();
    }




}
