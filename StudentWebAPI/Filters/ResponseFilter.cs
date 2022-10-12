using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace StudentWebAPI.Filters;

public class ResponseFilter : IAsyncResultFilter
{
    private readonly ILogger _logger;

    public ResponseFilter(ILogger logger)
    {
        _logger = logger;
    }

    public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
        if (!(context.Result is EmptyResult))
        {
            var result = await next();
            _logger.LogInformation("Response: " + JsonConvert.SerializeObject(result.Result));
        }
        else
        {
            context.Cancel = true;
        }
    }
}
    

    


