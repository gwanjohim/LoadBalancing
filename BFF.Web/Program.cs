using BFF.Web.Config;
using MMLib.SwaggerForOcelot.DependencyInjection;
using Ocelot.DependencyInjection;
using Ocelot.Provider.Eureka;
using Ocelot.Provider.Polly;
using Steeltoe.Discovery.Client;
using Steeltoe.Discovery.Eureka;

namespace BFF.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.


            var routes = "";
#if DEBUG
            routes = "/c/Users/gwanjohi/Documents/Projects/SDDemoDocker/Routes.dev/";
#else
routes = "Routes.prod";
#endif

            builder.Configuration.AddOcelotWithSwaggerSupport(options =>
            {
                options.Folder = routes;

            });

            builder.Services.AddOcelot(builder.Configuration).AddEureka().AddPolly();
            builder.Services.AddSwaggerForOcelot(builder.Configuration);
            builder.Services.AddServiceDiscovery(o => o.UseEureka());

            builder.Host.ConfigureAppConfiguration((hostingContext, config) =>
            {
                config.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.local.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{hostingContext.HostingEnvironment.EnvironmentName}.json", optional: true)
                .AddOcelot(routes, builder.Environment)
                .AddEnvironmentVariables();
            });

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                //app.UseSwaggerUI();
            }

            //app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseSwaggerForOcelotUI(options => {
                options.PathToSwaggerGenerator = "/swagger/docs";
                options.ReConfigureUpstreamSwaggerJson = AlterUpstream.AlterUpstreamSwaggerJson;
            });


            app.MapControllers();

            app.Run();
        }
    }
}