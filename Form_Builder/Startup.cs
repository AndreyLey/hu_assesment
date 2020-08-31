using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Form_Builder.DB;
using Form_Builder.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SearchEngine.DB;

namespace Form_Builder
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {           
            string dbHost = Environment.GetEnvironmentVariable("DB_HOST");
            if (String.IsNullOrEmpty(dbHost))
            {
                Console.WriteLine("Host for db isn't configurated");
            }
            string dbPort = Environment.GetEnvironmentVariable("DB_PORT");
            if (String.IsNullOrEmpty(dbPort))
            {
                Console.WriteLine("Port for db isn't configurated");
            }
            services.AddSingleton<DbConnectionString>(new DbConnectionString(dbHost, dbPort));
            services.Configure<DbSetting>(Configuration.GetSection(nameof(DbSetting)));     
            services.AddSingleton<IDbSetting>(sp => sp.GetRequiredService<IOptions<DbSetting>>().Value);
            services.AddSingleton<IDBAccessLayer, MongoDbAccessLayer>();
            services.AddSingleton<IFormManager, FormManager>();
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.AllowAnyOrigin().WithOrigins("http://localhost:3000").AllowAnyHeader().AllowAnyMethod();
                    });
            });
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseCors();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
