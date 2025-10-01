using Client.Presentation.Abstractions.Dialogs;
using Microsoft.Win32;
using System.IO;

namespace Client.UI.Abstractions.Dialogs;

internal class SaveDialogService : ISaveDialogService
{
    private readonly SaveFileDialog _saveFileDialog;

    public SaveDialogService()
    {
        _saveFileDialog = new SaveFileDialog()
        {
            DefaultExt = ".json",
            Filter = "Json Files (*.json)|*.json|All Files (*.*)|*.*",
            InitialDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads")
        };
    }

    public string InitialDirectory
    {
        get => _saveFileDialog.InitialDirectory;
        set => _saveFileDialog.InitialDirectory = value;
    }

    public string Filter
    {
        get => _saveFileDialog.Filter;
        set => _saveFileDialog.Filter = value;
    }

    public string FileName => _saveFileDialog.FileName;

    public string DefaultFileName
    {
        get => _saveFileDialog.FileName;
        set => _saveFileDialog.FileName = value;
    }

    public string DefaultExt
    {
        get => _saveFileDialog.DefaultExt;
        set => _saveFileDialog.DefaultExt = value;
    }

    public bool ShowFileDialog() => _saveFileDialog.ShowDialog() == true;

    public async Task<bool> ShowFileDialogAsync()
        => await System.Windows.Application.Current.Dispatcher.InvokeAsync(() => _saveFileDialog.ShowDialog() == true);
}
