using MyEFCore.Infrastrcture.Context;
using Microsoft.EntityFrameworkCore;

namespace MyEFCore
{
    public static class MyEFCoreDbContextPool
    {
        public static IServiceCollection AddMyEFCoreContext(
            this IServiceCollection serviceCollection,
            string connectionString,
            bool sensitiveDataLoggingEnabled,
            bool useDetailedLog = false)
        {
            serviceCollection.AddEntityFrameworkSqlServer();
            serviceCollection.AddEntityFrameworkProxies();
            return serviceCollection.AddDbContextPool<MyEFCoreContext>((service, options) =>
            {
                if (useDetailedLog)
                {
                    options.LogTo(System.Console.WriteLine);
                }
                options.UseSqlServer(connectionString, o =>
                {
                    o.MaxBatchSize(42);
                });
                options.UseInternalServiceProvider(service);
                options.EnableSensitiveDataLogging(sensitiveDataLoggingEnabled);
            });
        }
    }
}
