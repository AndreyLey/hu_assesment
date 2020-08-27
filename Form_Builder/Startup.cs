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
