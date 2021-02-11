using Microsoft.AspNetCore.Builder;

namespace Ondato.Api.AppConfigs
{
    public static  class ExceptionMiddlewareExtensions {
        public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
    
}
