namespace Client.Presentation.Abstractions.Dialogs;

public interface IFileDialogService
{
    string InitialDirectory { get; set; }
    string Filter { get; set; }
    string FileName { get; set; }
    string[] FileNames { get; }
    bool Multiselect { get; set; }

    bool ShowFileDialog();
    Task<bool> ShowFileDialogAsync();
}
