using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace Mango.Services.Shared.Extensions
{
    public static class HealthCheckExtensions
    {
        /// <summary>
        /// Adds health checks for a Mango microservice with database
        /// </summary>
        public static IHealthChecksBuilder AddMangoHealthChecks<TDbContext>(
            this IServiceCollection services,
            string serviceName) where TDbContext : DbContext
        {
            return services.AddHealthChecks()
                .AddCheck("self", () => HealthCheckResult.Healthy($"{serviceName} is running"))
                .AddDbContextCheck<TDbContext>(
                    name: "database",
                    failureStatus: HealthStatus.Unhealthy);
        }

        /// <summary>
        /// Maps /health endpoint with detailed JSON response
        /// </summary>
        public static WebApplication UseMangoHealthChecks(this WebApplication app)
        {
            app.MapHealthChecks("/health", new HealthCheckOptions
            {
                ResponseWriter = async (context, report) =>
                {
                    context.Response.ContentType = "application/json";

                    var result = JsonSerializer.Serialize(new
                    {
                        status = report.Status.ToString(),
                        timestamp = DateTime.UtcNow,
                        checks = report.Entries.Select(e => new
                        {
                            name = e.Key,
                            status = e.Value.Status.ToString(),
                            description = e.Value.Description,
                            duration = $"{e.Value.Duration.TotalMilliseconds}ms",
                            exception = e.Value.Exception?.Message
                        }),
                        totalDuration = $"{report.TotalDuration.TotalMilliseconds}ms"
                    }, new JsonSerializerOptions
                    {
                        WriteIndented = true
                    });

                    await context.Response.WriteAsync(result);
                }
            });

            return app;
        }
    }
}
