using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace Ondato.DB.Helpers
{
    public static class DatabaseSeeder
    {
        public static IHost SeedDatabase(this IHost host) {

            using (var scope = host.Services.CreateScope())
            {
                using (var context = scope.ServiceProvider.GetRequiredService<OndatoContext>())
                {
                    try
                    {
                        
                        
                    }
                    catch (Exception ex)
                    {
                        //Log errors or do anything you think it's needed
                        throw;
                    }
                }
            }
            return host;
        }
    }
}
