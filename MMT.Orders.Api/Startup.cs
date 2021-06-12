using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MMT.Orders.Api.Convertors;
using MMT.Orders.Common.Configuration;
using MMT.Orders.Contracts.Profiles;
using MMT.Orders.Data;
using MMT.Orders.Services;

namespace MMT.Orders.Api
{
    public class Startup
    {
        public Startup( IConfiguration configuration )
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices( IServiceCollection services )
        {
            services.AddControllers()
                .AddJsonOptions( options =>
                {
                    options.JsonSerializerOptions.Converters.Add( new JsonDateFormatter() );
                } );

            services.AddSwaggerGen();

            services.AddDbContext<OrderDbContext>( options =>
                 options.UseSqlServer( Configuration.GetConnectionString( "DefaultConnection" ) ) );

            services.AddDataAccess();

            services.AddServices();

            services.AddAutoMapper( typeof( OrderProfile ) );

            services.Configure<ApiKeys>( x => Configuration.GetSection( "Keys" ).Bind( x ) );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure( IApplicationBuilder app, IWebHostEnvironment env )
        {
            if ( env.IsDevelopment() )
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();

            app.UseSwaggerUI( c =>
            {
                c.SwaggerEndpoint( "/swagger/v1/swagger.json", "Orders API" );
            } );

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints( endpoints =>
             {
                 endpoints.MapControllers();
             } );
        }
    }
}
