namespace Client.Presentation.Abstractions.Dialogs;

public interface ISaveDialogService
{
    string InitialDirectory { get; set; }
    string Filter { get; set; }
    string FileName { get; }
    string DefaultFileName { get; set; }
    string DefaultExt { get; set; }
    bool ShowFileDialog();
    Task<bool> ShowFileDialogAsync();
}