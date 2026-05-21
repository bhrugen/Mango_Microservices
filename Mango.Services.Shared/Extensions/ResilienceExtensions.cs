using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Http.Resilience;
using Polly;

namespace Mango.Services.Shared.Extensions
{
    public static class ResilienceExtensions
    {
        /// <summary>
        /// Adds standard resilience policies (retry, circuit breaker, timeout) to an HttpClient
        /// </summary>
        /// <param name="builder">HTTP client builder</param>
        /// <param name="serviceName">Name of the service for logging/metrics</param>
        /// <returns>HTTP client builder for chaining</returns>
        public static IHttpClientBuilder AddStandardResilienceHandler(
            this IHttpClientBuilder builder,
            string serviceName)
        {
            builder.AddStandardResilienceHandler(options =>
            {
                // Retry Configuration
                options.Retry = new HttpRetryStrategyOptions
                {
                    MaxRetryAttempts = 3,
                    Delay = TimeSpan.FromSeconds(1),
                    BackoffType = DelayBackoffType.Exponential, // 1s, 2s, 4s
                    UseJitter = true, // Add randomness to prevent thundering herd
                    ShouldHandle = new PredicateBuilder<HttpResponseMessage>()
                        .Handle<HttpRequestException>()
                        .HandleResult(response => 
                            response.StatusCode == System.Net.HttpStatusCode.RequestTimeout ||
                            response.StatusCode == System.Net.HttpStatusCode.ServiceUnavailable ||
                            response.StatusCode == System.Net.HttpStatusCode.GatewayTimeout)
                };

                // Circuit Breaker Configuration
                options.CircuitBreaker = new HttpCircuitBreakerStrategyOptions
                {
                    FailureRatio = 0.5, // Break if 50% of requests fail
                    MinimumThroughput = 10, // Need at least 10 requests before breaking
                    SamplingDuration = TimeSpan.FromSeconds(30), // Monitor window
                    BreakDuration = TimeSpan.FromSeconds(15), // Stay open for 15s before retry
                    ShouldHandle = new PredicateBuilder<HttpResponseMessage>()
                        .Handle<HttpRequestException>()
                        .HandleResult(response =>
                            response.StatusCode == System.Net.HttpStatusCode.RequestTimeout ||
                            response.StatusCode == System.Net.HttpStatusCode.ServiceUnavailable ||
                            response.StatusCode == System.Net.HttpStatusCode.GatewayTimeout)
                };

                // Timeout Configuration
                options.TotalRequestTimeout = new HttpTimeoutStrategyOptions
                {
                    Timeout = TimeSpan.FromSeconds(10) // Total timeout including retries
                };

                // Attempt Timeout (per individual request)
                options.AttemptTimeout = new HttpTimeoutStrategyOptions
                {
                    Timeout = TimeSpan.FromSeconds(3) // Each attempt times out after 3s
                };
            });

            return builder;
        }
    }
}
