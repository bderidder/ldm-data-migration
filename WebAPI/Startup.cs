using LaDanse.Migration.KeyMappers;
using LaDanse.Migration.Migrations;
using LaDanse.Source;
using LaDanse.Target;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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
                    "server=localhost;port=3357;database=LDMDevelopment;user=root;password=sql;GuidFormat=None",
                    x => x.ServerVersion("5.7.30-mysql")
                ));
                
            services.AddDbContext<TargetDbContext>(options => options
                .UseMySql(
                    "server=localhost;port=3380;database=LDMMigrationTest;user=root;password=sql",
                    x => x.ServerVersion("8.0.20-mysql")
                ));

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
