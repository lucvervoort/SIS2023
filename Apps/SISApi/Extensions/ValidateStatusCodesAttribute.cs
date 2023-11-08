//using Swashbuckle.AspNetCore.Annotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Controllers;

namespace SISApi.Extensions
{
    public class ValidateStatusCodesAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            bool check = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development";

#if DEBUG
            check = true;
#endif

            if (check)
            {
                if (context.Result is Microsoft.AspNetCore.Mvc.Infrastructure.IStatusCodeActionResult result)
                {
                    if (context.ActionDescriptor is ControllerActionDescriptor descriptor)
                    {
                        var customAttributes = descriptor.MethodInfo.CustomAttributes.Where(a =>
                        a.AttributeType.FullName == "Swashbuckle.AspNetCore.Annotations.SwaggerResponseAttribute" ||
                        a.AttributeType.FullName == "Microsoft.AspNetCore.Mvc.ProducesResponseTypeAttribute");

                        var args = customAttributes.Select(s => s.ConstructorArguments.Where(arg => arg.ArgumentType == typeof(int)));

                        var res = args.Any(a => a.Any(v => v.ArgumentType.Name == "Int32" && v.Value!.Equals((int)result!.StatusCode!)));

                        if (!res)
                        {
                            context.Result = new ObjectResult($"OpenAPI specification exception, unsupported status code: {result!.StatusCode}\n" +
                                $"action: {context.ActionDescriptor.DisplayName}")
                            { StatusCode = 500 };
                        }
                    }

                }
            }
        }

    }
}
