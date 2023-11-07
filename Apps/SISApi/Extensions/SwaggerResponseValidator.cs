using Microsoft.AspNetCore.Http.Features;
//using Swashbuckle.AspNetCore.Annotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Controllers;
using Swashbuckle.AspNetCore.Annotations;

namespace WebApiDocumentation.Extensions
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

    public class SwaggerResponseCheck
    {
        private readonly RequestDelegate _next;
        public SwaggerResponseCheck(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            bool check = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development";

#if DEBUG
            check = true; // actief: niet grijs => DEBUG geconfigureerd als tag
#endif
            if (check)
            {
                using (var buffer = new MemoryStream())
                {
                    var stream = context.Response.Body;
                    context.Response.Body = buffer;
                    await _next(context);

                    var endpoint = context.Features.Get<IEndpointFeature>()?.Endpoint;
                    var attributes = endpoint?.Metadata.OfType<SwaggerResponseAttribute>(); 
                    var producesAttributes = endpoint?.Metadata?.OfType<ProducesResponseTypeAttribute>();

                    var error = false;
                    if (attributes != null || producesAttributes != null)
                    {
                        if (attributes != null && !attributes.Any(a => a.StatusCode == context.Response.StatusCode))
                        {
                            error = true;
                        } 
                        if(error && producesAttributes != null && producesAttributes.Any(a => a.StatusCode == context.Response.StatusCode))
                        {
                            error = false;
                        }
                    }
                    if (error)
                    {
                        context.Response.StatusCode = 500;
                        buffer.Seek(0, SeekOrigin.Begin);
                        await context.Response.WriteAsync($"OpenAPI specification exception, unsupported status code: {context.Response.StatusCode}\npath: {context.Request.Path}");
                    }
                    buffer.Seek(0, SeekOrigin.Begin);

                    await context.Response.Body.CopyToAsync(stream);
                    context.Response.Body = stream;
                }
            }
            else
            {
                await _next(context);
            }

        }
    }

    public static class StatusCodeExtensions
    {
        public static IApplicationBuilder UseSwaggerResponseCheck(this IApplicationBuilder app)
        {
            return app.UseMiddleware<SwaggerResponseCheck>();
        }

        public static IActionResult Validate(this Microsoft.AspNetCore.Mvc.Infrastructure.IStatusCodeActionResult result)
        {
            bool check = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development";

#if DEBUG
            check = true;
#endif

            if (check)
            {
                var m = System.Reflection.MethodBase.GetCurrentMethod();
                var frames = new System.Diagnostics.StackTrace(false).GetFrames();
                var st = Array.FindIndex(frames, frame =>
                    frame.GetMethod() == m) + 1;

                var customAttributes = frames[st].GetMethod()!.CustomAttributes.Where(a =>
                    a.AttributeType.FullName == "Swashbuckle.AspNetCore.Annotations.SwaggerResponseAttribute" ||
                    a.AttributeType.FullName == "Microsoft.AspNetCore.Mvc.ProducesResponseTypeAttribute");

                var args = customAttributes.Select(s => s.ConstructorArguments.Where(arg => arg.ArgumentType == typeof(int)));

                var res = args.Any(a => a.Any(v => v.ArgumentType.Name == "Int32" && v.Value!.Equals((int)result.StatusCode!)));

                if (!res)
                {
                    throw new InvalidOperationException($"OpenAPI specification exception, unsupported status code: {result.StatusCode}");
                }
            }

            return result;
        }
    }
}
