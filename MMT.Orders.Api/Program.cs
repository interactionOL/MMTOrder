using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace MMT.Orders.Api
{
    public class Program
    {
        public static void Main( string[] args )
        {
            CreateHostBuilder( args ).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder( string[] args ) =>
            Host.CreateDefaultBuilder( args )
                .ConfigureWebHostDefaults( webBuilder =>
                 {
                     webBuilder.ConfigureAppConfiguration( ( hostingContext, config ) =>
                     {
                         var env = hostingContext.HostingEnvironment;

                         config.AddJsonFile( "appsettings.json", optional: false, reloadOnChange: true )
                            .AddJsonFile( $"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true );

                         //So connection strings and secrets can be loaded from machine settings, rather than checked in constants
                         config.AddEnvironmentVariables( "MMTOrders" );
                     } );
                     webBuilder.UseStartup<Startup>();

                 } );
    }
}
