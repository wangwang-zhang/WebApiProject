using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Options;

namespace StudentWebAPI.Filters;

internal class ResponseWrapperExecutor : ObjectResultExecutor
{
    public ResponseWrapperExecutor(OutputFormatterSelector formatterSelector,
        IHttpResponseStreamWriterFactory writerFactory,
        ILoggerFactory loggerFactory, IOptions<MvcOptions> mvcOptions)
        : base(formatterSelector, writerFactory, loggerFactory, mvcOptions)
    {
    }

    public override Task ExecuteAsync(ActionContext context, ObjectResult result)
    {
        var response = new ResponseWrapper<object?>
        {
            Result = result.Value,
            Success = true
        };

        TypeCode typeCode = Type.GetTypeCode(result.Value?.GetType());
        if (typeCode == TypeCode.Object)
            result.Value = response;

        return base.ExecuteAsync(context, result);
    }
}