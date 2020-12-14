using Microsoft.AspNetCore.Builder;

namespace BudgetTestServer.Infrastructure.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseSwaggerUI(this IApplicationBuilder app)
        {
            app
                .UseSwagger()
                .UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Budget Planner Api");
                    options.RoutePrefix = string.Empty;
                });

            return app;
        }
    }
}
