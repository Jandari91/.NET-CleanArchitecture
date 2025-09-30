namespace Client.Presentation.Abstractions.Contracts;

public enum MessageButton
{
    OK = 0,
    OKCancel = 1,
    YesNoCancel = 3,
    YesNo = 4
}

public enum MessageIcon
{
    None = 0,
    Error = 16,
    Hand = 16,
    Stop = 16,
    Question = 32,
    Exclamation = 48,
    Warning = 48,
    Asterisk = 64,
    Information = 64
}

public enum MessageResult
{
    None = 0,
    OK = 1,
    Cancel = 2,
    Yes = 6,
    No = 7
}