using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TestSwitchApi.ApiModels;
using TestSwitchApi.Repositories;
using TestSwitchApi.Services;

namespace TestSwitchApi
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
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            services.AddControllers();
            services.AddTransient<ICandidatesRepo, CandidatesRepo>();
            if (env == "Production")
            {
                var dbservice = new DataBaseService();
                var dbConnectionString = dbservice.ConnectionStringBuilder();
                services.AddEntityFrameworkNpgsql()
                    .AddDbContext<TestSwitchDbContext>(opt =>
                        opt.UseNpgsql(dbConnectionString));
            }
            else
            {
                services.AddEntityFrameworkNpgsql()
                .AddDbContext<TestSwitchDbContext>(opt =>
              opt.UseNpgsql(Configuration.GetConnectionString("testSwitchConnection")));
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}