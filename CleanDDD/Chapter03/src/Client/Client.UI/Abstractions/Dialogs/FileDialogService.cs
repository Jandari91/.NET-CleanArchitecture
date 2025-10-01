using Client.Presentation.Abstractions.Dialogs;
using Microsoft.Win32;
using System.IO;

namespace Client.UI.Abstractions.Dialogs;

internal class FileDialogService : IFileDialogService
{
    private readonly OpenFileDialog _openFileDialog;

    public FileDialogService()
    {
        _openFileDialog = new OpenFileDialog
        {
            InitialDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads"),
            Filter = "Json Files (*.json)|*.json|All Files (*.*)|*.*",
            Multiselect = false
        };
    }

    public string InitialDirectory
    {
        get => _openFileDialog.InitialDirectory;
        set => _openFileDialog.InitialDirectory = value;
    }

    public string Filter
    {
        get => _openFileDialog.Filter;
        set => _openFileDialog.Filter = value;
    }

    public string FileName
    {
        get => _openFileDialog.FileName;
        set => _openFileDialog.FileName = value;
    }

    public string[] FileNames
    {
        get => _openFileDialog.FileNames;
    }

    public bool Multiselect
    {
        get => _openFileDialog.Multiselect;
        set => _openFileDialog.Multiselect = value;
    }

    public bool ShowFileDialog() => _openFileDialog.ShowDialog() == true;

    public async Task<bool> ShowFileDialogAsync()
        => await System.Windows.Application.Current.Dispatcher.InvokeAsync(() => ShowFileDialog());
}
