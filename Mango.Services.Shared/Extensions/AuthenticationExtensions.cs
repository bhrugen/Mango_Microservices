using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Mango.Services.Shared.Extensions
{
    public static class AuthenticationExtensions
    {
        /// <summary>
        /// Adds JWT Bearer authentication to the application.
        /// </summary>
        /// <param name="builder">The WebApplicationBuilder instance</param>
        /// <param name="secretConfigKey">Configuration key for JWT secret. Default: "ApiSettings:Secret"</param>
        /// <param name="issuerConfigKey">Configuration key for JWT issuer. Default: "ApiSettings:Issuer"</param>
        /// <param name="audienceConfigKey">Configuration key for JWT audience. Default: "ApiSettings:Audience"</param>
        /// <returns>The WebApplicationBuilder instance for chaining</returns>
        public static WebApplicationBuilder AddJwtAuthentication(
            this WebApplicationBuilder builder,
            string secretConfigKey = "ApiSettings:Secret",
            string issuerConfigKey = "ApiSettings:Issuer",
            string audienceConfigKey = "ApiSettings:Audience")
        {
            var secret = builder.Configuration.GetValue<string>(secretConfigKey);
            var issuer = builder.Configuration.GetValue<string>(issuerConfigKey);
            var audience = builder.Configuration.GetValue<string>(audienceConfigKey);

            if (string.IsNullOrEmpty(secret))
            {
                throw new InvalidOperationException($"JWT secret not configured at '{secretConfigKey}'");
            }

            var key = Encoding.ASCII.GetBytes(secret);

            builder.Services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidIssuer = issuer,
                    ValidAudience = audience,
                    ValidateAudience = true
                };
            });

            return builder;
        }
    }
}
