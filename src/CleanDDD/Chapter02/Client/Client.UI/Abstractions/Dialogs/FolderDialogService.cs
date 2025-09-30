using Client.Presentation.Abstractions.Dialogs;
using Microsoft.Win32;
using System.IO;

namespace Client.UI.Abstractions.Dialogs
{
    internal class FolderDialogService : IFolderDialogService
    {
        private readonly OpenFileDialog _openFileDialog;
        public FolderDialogService()
        {
            _openFileDialog = new OpenFileDialog
            {
                InitialDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads"),
                Filter = "Folders|*.",
                ValidateNames = false,
                CheckFileExists = false,
                CheckPathExists = true,
                FileName = "Please, select a folder",
            };
        }

        public string FolderName
        {
            get => Path.GetDirectoryName(_openFileDialog.FileName) ?? throw new ArgumentNullException($"{_openFileDialog.FileName} is null");
        }

        public string InitialDirectory
        {
            get => _openFileDialog.InitialDirectory;
            set => _openFileDialog.InitialDirectory = value;
        }

        public bool ShowFileDialog() => _openFileDialog.ShowDialog() == true;

        public async Task<bool> ShowFileDialogAsync()
            => await System.Windows.Application.Current.Dispatcher.InvokeAsync(() => ShowFileDialog());
    }
}
