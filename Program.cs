using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.PlatformAbstractions;
using MyEFCore;
using MyEFCore.Infrastrcture.Context;
using MyEFCore.Infrastrcture.Interface.Repositories;
using MyEFCore.Infrastrcture.Interface.Services;
using MyEFCore.Infrastrcture.Repositories;
using MyEFCore.Infrastrcture.Services;

internal class Program
{
    private static async Task Main(string[] args)
    {
        //var host = CreateHostBuilder(args).Build();

        //Initialize(host);

        //await host.RunAsync();

        var builder = WebApplication.CreateBuilder(args);
        // Add services to the container.
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Configuration.GetConnectionString("MyEFCore");
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddMvc();
        builder.Services.AddHttpContextAccessor();
        builder.Services.AddDbContext<MyEFCoreContext>();
        builder.Services.AddScoped<IPeopleRepository, PeopleRepository>();
        builder.Services.AddScoped<IPeopleService, PeopleService>();

        var loggerFactory = LoggerFactory.Create(builder =>
        {
            builder.ClearProviders();
            builder.AddConsole();
            builder.AddEventLog();
        });
        builder.Services.AddOptions();
        builder.Services.AddMvc(options =>
        {
            options.SuppressAsyncSuffixInActionNames = false;
        });
        builder.Services.AddDbContext<MyEFCoreContext>(builder.Configuration.GetConnectionString("MyEFCore"), true);
        builder.Services.AddScoped<IPeopleRepository, PeopleRepository>();
        builder.Services.AddScoped<IPeopleService, PeopleService>();
        var app = builder.Build();
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args)
    {
        return Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((context, builder) =>
            {
                builder.SetBasePath(PlatformServices.Default.Application.ApplicationBasePath);
            })
            .ConfigureWebHostDefaults(webHostBuilder => webHostBuilder.UseStartup<Startup>());
    }

    public static void Initialize(IHost host)
    {
        using var scope = host.Services.CreateScope();
        var logger = scope.ServiceProvider.GetService<ILogger<IHost>>();
        //var containerBuilder = scope.ServiceProvider.GetService<IContainerBuilder>();
        logger.LogInformation("-------------------END-------------------");
    }
}