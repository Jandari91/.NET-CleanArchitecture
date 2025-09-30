using System.ComponentModel;

namespace Client.Business.Core.Application.Mvvm;

public interface IDialogBase : INotifyPropertyChanged
{
    bool IsValid { get; }
}
