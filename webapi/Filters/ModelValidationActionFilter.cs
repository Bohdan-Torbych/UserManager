using Microsoft.AspNetCore.Mvc.Filters;

namespace webapi.Filters;

public class ModelValidationActionFilter : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (!context.ModelState.IsValid)
        {
            var errorMessages = context.ModelState.Values
                .SelectMany(value => value.Errors)
                .Select(error => error.ErrorMessage)
                .ToList();

            throw new ArgumentException(string.Join("\n", errorMessages));
        }
        base.OnActionExecuting(context);
    }
}