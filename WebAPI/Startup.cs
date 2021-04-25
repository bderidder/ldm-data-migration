using System;
using LaDanse.Migration.KeyMappers;
using LaDanse.Migration.Migrations;
using LaDanse.Source.MySql;
using LaDanse.Target.MySql;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Target.Shared;
using Target.SqlServer;

namespace WebAPI
{
    public enum DbTarget
    {
        MySql,
        SqlServer
    }
    
    public class Startup
    {
        private DbTarget DbTarget { get; set; }
        
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
                    "server=192.168.1.13;port=3357;database=LDMDevelopment;user=root;password=sql;GuidFormat=None",
                    new MySqlServerVersion(new Version(5, 7, 32)),
                    mySqlOptions => mySqlOptions
                        .CharSetBehavior(CharSetBehavior.NeverAppend)
                ));

            DbTarget = DbTarget.MySql;

            switch (DbTarget)
            {
                case DbTarget.MySql:
                    services.AddDbContext<MySqlTargetDbContext>(options => options
                        .UseMySql(
                            "server=192.168.1.13;port=3380;database=LDMDevelopmentDotNet;user=root;password=sql",
                            new MySqlServerVersion(new Version(8, 0, 22)),
                            mySqlOptions => mySqlOptions
                                .CharSetBehavior(CharSetBehavior.NeverAppend)
                        ));
                
                    services.AddScoped<ITargetDbContext>(provider => provider.GetService<MySqlTargetDbContext>());
                    break;
                case DbTarget.SqlServer:
                    services.AddDbContext<SqlServerTargetDbContext>(options =>
                        options.UseSqlServer(
                            "Server=(LocalDB)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=D:\Data\MyDB1.mdf"
                            // "Server=tcp:192.168.1.13,1433;Initial Catalog=LDMMigrationTest;Persist Security Info=False;User ID=sa;Password=BC8.27tX;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;"
                        ));
                
                    services.AddScoped<ITargetDbContext>(provider => provider.GetService<SqlServerTargetDbContext>());
                    break;
            }
            
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
