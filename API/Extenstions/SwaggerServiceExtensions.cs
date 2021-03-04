using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace API.Extenstions
{
    public static class SwaggerServiceExtensions
    {
        public static IServiceCollection AddSwaggerServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo() {Title = "API", Version = "v1"}); });
            return serviceCollection;
        }

        public static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder app)
        {
            app.UseSwagger(c => { c.SerializeAsV2 = true; });
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApplication v1"));
            return app;
        }
    }
}