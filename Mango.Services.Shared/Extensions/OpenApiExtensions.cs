using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi;
using Scalar.AspNetCore;

namespace Mango.Services.Shared.Extensions
{
    public static class OpenApiExtensions
    {
        /// <summary>
        /// Adds OpenAPI/Swagger documentation with optional JWT Bearer authentication.
        /// </summary>
        /// <param name="services">The IServiceCollection instance</param>
        /// <param name="title">The API title</param>
        /// <param name="description">The API description</param>
        /// <param name="version">The API version. Default: "v1"</param>
        /// <param name="requiresAuth">Whether the API requires JWT authentication. Default: true</param>
        /// <returns>The IServiceCollection instance for chaining</returns>
        public static IServiceCollection AddMangoOpenApi(
            this IServiceCollection services,
            string title,
            string description,
            string version = "v1",
            bool requiresAuth = true)
        {
            services.AddOpenApi(options =>
            {
                options.AddDocumentTransformer((document, context, cancellationToken) =>
                {
                    document.Info = new OpenApiInfo
                    {
                        Title = title,
                        Version = version,
                        Description = description
                    };

                    if (requiresAuth)
                    {
                        document.Components ??= new();
                        document.Components.SecuritySchemes = new Dictionary<string, IOpenApiSecurityScheme>
                        {
                            ["Bearer"] = new OpenApiSecurityScheme
                            {
                                Type = SecuritySchemeType.Http,
                                Scheme = "bearer",
                                BearerFormat = "JWT",
                                Description = "Enter JWT Bearer token"
                            }
                        };

                        document.Security =
                        [
                            new OpenApiSecurityRequirement
                            {
                                { new OpenApiSecuritySchemeReference("Bearer"), new List<string>() }
                            }
                        ];
                    }

                    return Task.CompletedTask;
                });
            });

            return services;
        }

        /// <summary>
        /// Configures OpenAPI middleware and Scalar API documentation in development environment.
        /// </summary>
        /// <param name="app">The WebApplication instance</param>
        /// <param name="apiTitle">The title to display in Scalar UI</param>
        /// <returns>The WebApplication instance for chaining</returns>
        public static WebApplication UseMangoOpenApi(
            this WebApplication app,
            string apiTitle)
        {
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.MapScalarApiReference(option =>
                {
                    option.Title = apiTitle;
                });
            }

            return app;
        }
    }
}
