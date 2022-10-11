using Microsoft.AspNetCore.Mvc.Filters;

namespace StudentWebAPI.Filters;

public class ActionFilter : IActionFilter
{
    private readonly ILogger _logger;

    public ActionFilter(ILogger logger)
    {
        _logger = logger;
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        _logger.LogInformation("[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "]:["+
                               context.HttpContext.Request.Method + "]" + context.HttpContext.Request.Path + ",Request TraceID:" +
                               context.HttpContext.TraceIdentifier);
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        _logger.LogInformation("[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "]:Response" +
                               context.HttpContext.Response.Body);//question: get a HttpResponseStream not object or json 
    }
}