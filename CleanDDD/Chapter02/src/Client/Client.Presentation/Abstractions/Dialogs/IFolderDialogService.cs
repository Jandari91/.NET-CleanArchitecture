namespace Client.Presentation.Abstractions.Dialogs;

public interface IFolderDialogService
{
    string InitialDirectory { get; set; }
    string FolderName { get; }
    bool ShowFileDialog();
    Task<bool> ShowFileDialogAsync();
}
