﻿using Kreta.Context;

namespace Kreta.Extensions
{
    public static class WebApplicationExtension
    {
        public static void ConfigureWebApp(this WebApplication app)
        {
            app.ConfigureWebAppCors();
            app.ConfigureInMemoryTestData();
        }

        private static void ConfigureWebAppCors(this WebApplication app)
        {
            app.UseCors("KretaCors");
        }

        private static void ConfigureInMemoryTestData(this WebApplication app)
        {
            // InMemory database data
            using (var scope = app.Services.CreateAsyncScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<KretaInMemoryContext>();
                // InMemory test data
                dbContext.Database.EnsureCreated();
            }
        }
    }
}