using Microsoft.AspNetCore.Http.Features;
//using Swashbuckle.AspNetCore.Annotations;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace SISApi.Extensions
{
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
                        await context.Response.WriteAsync($"OpenAPI specification exception, unsupported status code: {context.Response.StatusCode}\nPath: {context.Request.Path}");
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
}
