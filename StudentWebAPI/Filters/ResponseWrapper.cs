using System.Text.Json.Serialization;

namespace StudentWebAPI.Filters;

internal class ResponseWrapper<T>
{
    public bool Success { set; get; }
    public T Result { set; get; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Error Error { get; set; }
}

internal class Error
{
    public string ErrorMessage { get; set; }
}