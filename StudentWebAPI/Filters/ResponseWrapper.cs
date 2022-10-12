namespace StudentWebAPI.Filters;

internal class ResponseWrapper<T>
{
    public bool Success { set; get; }
    public T Result { set; get; }

}