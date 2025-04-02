using Microsoft.EntityFrameworkCore;

namespace Quiziffy_App.Data
{
    public static class DataExtensions
    {
        public static async Task InitializeDbAsync(this IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            await dbContext.Database.MigrateAsync();

            var logger = serviceProvider
                .GetRequiredService<ILoggerFactory>()
                .CreateLogger("DB Initializer");
            logger.LogInformation(5, "The database is ready!");
        }
    }
}
