namespace Api.Domain.Abstractions;

[Serializable]
public class DomainException : Exception
{
    public string? Code { get; }

    public DomainException(string message, string? code = null) : base(message)
        => Code = code;

    public DomainException(string message, Exception inner, string? code = null)
        : base(message, inner) => Code = code;

    public override string ToString()
        => Code is null ? base.ToString() : $"[{Code}] {base.ToString()}";
}
