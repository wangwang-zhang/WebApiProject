using System.Diagnostics.CodeAnalysis;

namespace StudentWebAPI.Filters;

internal class ResponseWrapper<T>
{
    public bool Success { set; get; }
    public T Result { set; get; }

    [AllowNull]
    public Error Error { get; set; }

}

internal class Error
{
    public string ErrorMessage { get; set; }
}