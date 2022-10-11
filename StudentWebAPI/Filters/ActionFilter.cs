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
        
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
       
    }
}