using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Mango.Services.Shared.Extensions
{
    public static class DatabaseExtensions
    {
        /// <summary>
        /// Applies pending database migrations for the specified DbContext.
        /// </summary>
        /// <typeparam name="TContext">The DbContext type to apply migrations for</typeparam>
        /// <param name="app">The WebApplication instance</param>
        /// <returns>The WebApplication instance for chaining</returns>
        public static WebApplication ApplyMigrations<TContext>(this WebApplication app) 
            where TContext : DbContext
        {
            using var scope = app.Services.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<TContext>();

            if (db.Database.GetPendingMigrations().Any())
            {
                db.Database.Migrate();
            }

            return app;
        }
    }
}
