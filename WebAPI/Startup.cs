using LaDanse.Source;
using LaDanse.Target;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Migration.KeyMappers;
using Migration.Migrations;

namespace WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<SourceDbContext>(options => options
                .UseMySql(
                    "server=localhost;port=3306;database=LDMMigration;user=root;password=sql;GuidFormat=None",
                    x => x.ServerVersion("5.7.30-mysql")
                ));
                
            services.AddDbContext<TargetDbContext>(options => options
                .UseMySql(
                    "server=localhost;port=33061;database=LDMMigrationTarget;user=root;password=sql",
                    x => x.ServerVersion("8.0.20-mysql")
                )
                .EnableSensitiveDataLogging());

            services.AddKeyMappers();
            services.AddMigrations();
            
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
