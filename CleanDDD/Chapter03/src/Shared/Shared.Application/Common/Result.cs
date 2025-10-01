namespace Shared.Application.Common;

// 값 없는 성공을 표현
public readonly record struct Unit;

public readonly record struct Error(string Message, string Code = "");

// 값 없는 Result
public readonly record struct Result
{
    public bool IsSuccess { get; }
    public Error Error { get; }

    private Result(bool ok, in Error error)
    {
        IsSuccess = ok;
        Error = error; // ok=true면 default(Error) (non-null struct)
    }

    public static Result Ok() => new(true, default);
    public static Result Fail(string message, string code = "") => new(false, new Error(message, code));

    // 편의 메서드(선택)
    public void EnsureSuccess()
    {
        if (!IsSuccess) throw new InvalidOperationException($"Operation failed: {Error.Code} {Error.Message}");
    }
}

// 값이 있는 Result<T>
public readonly record struct Result<T>
{
    private readonly T _value;    // 내부 보관
    public bool IsSuccess { get; }
    public Error Error { get; }

    // 성공 생성자
    private Result(T value)
    {
        IsSuccess = true;
        _value = value;
        Error = default; // non-null struct
    }

    // 실패 생성자
    private Result(in Error error)
    {
        IsSuccess = false;
        _value = default!; // 외부로 노출되지 않으므로 안전
        Error = error;
    }

    public static Result<T> Ok(T value) => new(value);
    public static Result<T> Fail(string message, string code = "") => new(new Error(message, code));

    // 성공시에만 값 접근
    public T Value => IsSuccess
        ? _value
        : throw new InvalidOperationException($"No value. Error: {Error.Code} {Error.Message}");

    // 편의 변환
    public static implicit operator Result<T>(T value) => Ok(value);

    // 유틸(선택)
    public Result<U> Map<U>(Func<T, U> f) =>
        IsSuccess ? Result<U>.Ok(f(_value)) : Result<U>.Fail(Error.Message, Error.Code);

    public Result<U> Bind<U>(Func<T, Result<U>> f) =>
        IsSuccess ? f(_value) : Result<U>.Fail(Error.Message, Error.Code);
}
