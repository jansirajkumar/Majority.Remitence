using System.Text.Json;
namespace Majority.RemittanceProvider.Api.Middlewares;

public class AuthorizationHandlerMiddleware
{
    private readonly RequestDelegate _next;
    private const string Authorization = "Authorization";
    private const string AccessKey = "AccessKey";

    public AuthorizationHandlerMiddleware
        (RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        if (!context.Request.Headers.TryGetValue(Authorization, out var extractedApiKey))
        {
            context.Response.StatusCode = 401;
            var result = JsonSerializer.Serialize(new { errorMessage = "Access key not valid or provided" });
            await context.Response.WriteAsync(result);
            return;
        }
        var appSettings = context.RequestServices.GetRequiredService<IConfiguration>();
        var apiKey = appSettings.GetValue<string>(AccessKey);
        if (!apiKey.Equals(extractedApiKey.FirstOrDefault()))
        {
            context.Response.StatusCode = 403;
            var result = JsonSerializer.Serialize(new { errorMessage = "Unauthorized client" });
            await context.Response.WriteAsync(result);
            return;
        }
        await _next(context);
    }
}

