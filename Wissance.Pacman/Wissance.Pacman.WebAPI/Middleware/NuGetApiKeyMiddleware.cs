using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;
using Wissance.Pacman.Data;
using Wissance.Pacman.Data.Entities;
using Wissance.Pacman.WebAPI.Data;
using Wissance.Pacman.WebAPI.Utils.Hash;

namespace Wissance.Pacman.WebAPI.Middleware
{
    public class NuGetApiKeyMiddleware
    {
        public NuGetApiKeyMiddleware(RequestDelegate next, IServiceScopeFactory serviceScopeFactory)
        {
            _next = next;
            _serviceScopeFactory = serviceScopeFactory;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            IServiceScope scope = _serviceScopeFactory.CreateScope();
            IServiceProvider sp = scope.ServiceProvider;
            ILogger<NuGetApiKeyMiddleware> logger = sp.GetRequiredService<ILoggerFactory>().CreateLogger<NuGetApiKeyMiddleware>();
            
            try
            {
                PacmanDbContext dbContext = sp.GetRequiredService<PacmanDbContext>();
                if (context.Request.Path.StartsWithSegments(KnownNuGetResourceMethods.PublishMethodPath))
                {
                    StringValues extractedApiKey = "";
                    if (!context.Request.Headers.TryGetValue("X-NuGet-ApiKey", out extractedApiKey))
                    {
                        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                        await context.Response.WriteAsync("X-NuGet-ApiKey key is missing.");
                        return;
                    }
                    
                    string keyHash = Sha256Hasher.HashToHexStr(extractedApiKey);
                    if (string.IsNullOrEmpty(keyHash))
                    {
                        logger.LogError($"keyHash is null for the \"{extractedApiKey}\"");
                        context.Response.StatusCode = StatusCodes.Status400BadRequest;
                        return;
                    }
                    ApiKey apiKey = await dbContext.ApiKeys.FirstOrDefaultAsync(k => string.Equals(k.KeyHash.ToLower(), keyHash.ToLower()));
                    
                    if (apiKey == null)
                    {
                        // check active and expiration
                    }
                }
            }
            catch (Exception e)
            {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                logger.LogError($"An error occurred during Invoking NuGetApiKeyMiddleware: \"{e.Message}\"");
            }
            finally
            {
                scope.Dispose();
            }
        }
        
        private readonly RequestDelegate _next;
        private readonly IServiceScopeFactory _serviceScopeFactory;
    }
}