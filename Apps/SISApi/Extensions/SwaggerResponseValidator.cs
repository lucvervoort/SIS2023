//using Swashbuckle.AspNetCore.Annotations;
using Microsoft.AspNetCore.Mvc;

namespace SISApi.Extensions
{

    public static class StatusCodeExtensions
    {
        public static IApplicationBuilder UseSwaggerResponseCheck(this IApplicationBuilder app)
        {
            return app.UseMiddleware<SwaggerResponseCheck>();
        }

        public static IActionResult Validate(this Microsoft.AspNetCore.Mvc.Infrastructure.IStatusCodeActionResult result)
        {
            bool check = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development";

            // Only while developing and debugging - speed up Release build
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
                    throw new InvalidOperationException($"OpenAPI specification exception, unsupported status code: {result.StatusCode}. Check your [ProducesResponseType] set.");
                }
            }

            return result;
        }
    }
}
